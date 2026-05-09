using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ApplyCardData : MonoBehaviour
{
    public CardDataSet cardDataSet;

    public TextMeshProUGUI cardName;
    public Image illustration;
    public TextMeshProUGUI description;
    public TextMeshProUGUI cost;
    public TextMeshProUGUI stats;

    void Start()
    {
        if(cardDataSet != null)
        {
            applyChosenData();
        }
    }
    void applyChosenData()
    {
        cardName.text = cardDataSet.cardName.ToString();
        description.text = cardDataSet.description.ToString();
        cost.text = cardDataSet.cost.ToString();
        stats.text = cardDataSet.stats.ToString();
    }
}
