using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Deck_Spawner : MonoBehaviour
{
    public List<GameObject> availableCards = new List<GameObject>();
    public CardDataSet[] cardData;

    public GameObject cardTemplate;
    public Transform deckPosition;

    public float cardVerticalOffset;

    public GameObject currentTopCard
    {
        get
        {
            if (availableCards.Count == 0)
                return null;

            return availableCards[^1];
        }
    }

    void Awake()
    {
        InstantiateCards();
    }

    void InstantiateCards()
    {

        List<CardDataSet> shuffledDeck = new(cardData);
        ShuffleCards(shuffledDeck);

        for (int i = 0; i < shuffledDeck.Count; i++)
        {
            //Instatiate Card at proper position
            Vector3 spawnPos = deckPosition.position + Vector3.up * (i * cardVerticalOffset);
            GameObject spawnedCard = Instantiate(cardTemplate, spawnPos, Quaternion.Euler(0, 0, 180));

            //Update card with correct data
            ApplyCardData cardScript = spawnedCard.GetComponent<ApplyCardData>();

            cardScript.SetData(shuffledDeck[i], this);
            availableCards.Add(spawnedCard);

        }
    }

    void ShuffleCards(List<CardDataSet> cardList)
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            int randIndex = Random.Range(i, cardList.Count);
            (cardList[i], cardList[randIndex]) = (cardList[randIndex], cardList[i]);
        }
    }

    public void TriggerTopCard(GameObject topCard)
    {
        availableCards.Remove(topCard);
        Destroy(topCard);
    }

}
