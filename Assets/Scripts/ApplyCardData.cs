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
    public bool isSelectedCard;

    [Header("Card Focus Animations")]
    public Transform focusedPosition;
    public Sequence sequence;
    //public Transform focusedRotation;


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

        // deckRef.TriggerTopCard(gameObject);

        
        if (!isSelectedCard)
        {       
            BringCardToFocus();

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

    public void BringCardToFocus()
    {
        sequence?.Kill();

         sequence = DOTween.Sequence();

        sequence.Append(transform.DORotate(new Vector3(-45f, 0, 0), 1.5f).SetEase(Ease.OutCubic));
        sequence.Join(transform.DOMove(focusedPosition.position, 2f).SetEase(Ease.OutCubic).OnComplete(() =>
            {
                isSelectedCard = true;
            }));
    }

    public void BringToHand(Transform handPosition)
    {
        sequence?.Kill();
        sequence = DOTween.Sequence();

        sequence.Append(transform.DORotate(new Vector3(0, 0, 0), 1.5f).SetEase(Ease.OutCubic));
        sequence.Join(transform.DOMove(handPosition.position, 2f).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            isSelectedCard = true;
        }));
    }
}

