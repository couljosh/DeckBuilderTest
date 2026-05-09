using UnityEngine;
using System.Collections.Generic;

public class Deck_Spawner : MonoBehaviour
{
    public List<CardDataSet> availableCards = new List<CardDataSet>();
    public CardDataSet[] cardData;

    public GameObject cardTemplate;
    public GameObject deckPosition;
    public float cardVerticalOffset;

    void Awake()
    {           
        InstantiateCards();
    }

    void InstantiateCards()
    {
        //collect all available cards to remove later
        for (int i = 0; i < cardData.Length; i++)
        {
            availableCards.Add(cardData[i]);
        }


        for (int i = 0; i < cardData.Length; i++)
        {
            //Intantiate card
            GameObject spawnedCard = Instantiate(cardTemplate, deckPosition.transform.position, Quaternion.Euler(0, 0, 180));
            
            //choose random data
            int chosenIndex = Random.Range(0, availableCards.Count);
            spawnedCard.GetComponent<ApplyCardData>().cardDataSet = availableCards[chosenIndex];

            //remove chosen data to avoid repeats
            availableCards.RemoveAt(chosenIndex);

            //increase spawn height to creat pile effect
            deckPosition.transform.position += new Vector3(0, cardVerticalOffset, 0);


        }
    }

}
