using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardDataSet", menuName = "Scriptable Objects/CardDataSet")]
public class CardDataSet : ScriptableObject
{
    public string cardID;
    public string cardName;
    public Sprite illustration;
    public string description;
    public string cost;
    public string stats;
     
}
