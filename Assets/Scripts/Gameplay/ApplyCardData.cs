using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ApplyCardData : MonoBehaviour
{
    [Header("Script References")]
    public CardDataSet cardDataSet;
    private Deck_Spawner deckRef;

    [Header("Card Placeholder References")]
    public TextMeshProUGUI cardName;
    public Image illustration;
    public TextMeshProUGUI description;
    public TextMeshProUGUI cost;
    public TextMeshProUGUI stats;

    [Header("Card State Checks")]
    public bool isTopCard;
    public bool isSelectedCard;

    [Header("Card Focus Animation")]
    public Transform focusedPosition;
    public Sequence sequence;
    public float easeDuration;


    private void Start()
    {
        focusedPosition = GameObject.FindGameObjectWithTag("focusedPosition").transform;
    }


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

        if (!isSelectedCard && HandManagement.instance.handCount <= 8)
        {
            BringCardToFocus();

        }
        else
        {
            deckRef.TriggerTopCard(gameObject);
            BringToHand();
        }
    }

    private void Update()
    {
        if (deckRef.currentTopCard == gameObject)
        {
            isTopCard = true;
        }
        else
        {
            isTopCard = false;
        }
    }


    // Animation From Deck -> Focus // ------------------------------------------------------------------------
    public void BringCardToFocus()
    {
        sequence?.Kill();

        sequence = DOTween.Sequence();

        sequence.Append(transform.DORotate(new Vector3(-45f, 0, 0), 1.2f).SetEase(Ease.OutCubic));
        sequence.Join(transform.DOMove(focusedPosition.position, easeDuration).SetEase(Ease.OutCubic).OnComplete(() =>
            {
                isSelectedCard = true;
            }));
    }


    // Animation From Focus -> Hand // ------------------------------------------------------------------------
    public void BringToHand()
    {
        Transform targetSlot = HandManagement.instance.GetNewSlot();

        if (targetSlot == null)
            return;


        sequence?.Kill();
        sequence = DOTween.Sequence();

        sequence.Append(transform.DORotate(new Vector3(0, 0, 0), 1.2f).SetEase(Ease.OutCubic));
        sequence.Join(transform.DOMove(targetSlot.position, easeDuration).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            isSelectedCard = true;
        }));
    }
}

