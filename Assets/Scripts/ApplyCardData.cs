using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ApplyCardData : MonoBehaviour
{
    public CardDataSet cardDataSet;
    private Deck_Spawner deckRef;

    public TextMeshProUGUI cardName;
    public Image illustration;
    public TextMeshProUGUI description;
    public TextMeshProUGUI cost;
    public TextMeshProUGUI stats;

    public bool isTopCard;

    void ApplyChosenData()
    {
        cardName.text = cardDataSet.cardName.ToString();
        description.text = cardDataSet.description.ToString();
        illustration.sprite = cardDataSet.illustration;
        cost.text = cardDataSet.cost.ToString();
        stats.text = cardDataSet.stats.ToString();
    }

    public void SetData(CardDataSet data, Deck_Spawner deckSpawnerScript)
    {
        cardDataSet = data;
        deckRef = deckSpawnerScript;

        ApplyChosenData();
    }

    private void OnMouseDown()
    {
        if (!isTopCard)
            return;

        deckRef.TriggerTopCard(gameObject);
    }

    private void Update()
    {
        if(deckRef.currentTopCard == gameObject) 
        {
            isTopCard = true;
        } else
        {
            isTopCard = false;
        }
    }

    public void BringCardToFocus()
    {
        Sequence sequence = DOTween.Sequence();

    }
}
