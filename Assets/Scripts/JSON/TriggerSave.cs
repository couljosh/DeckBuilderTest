using System.Collections.Generic;
using UnityEngine;

public class TriggerSave : MonoBehaviour
{
    public SaveData saveDataScript;

    public void OnSave()
    {
        List<string> cards = new List<string>()
        {
            "1", "2", "3", "4", "5", "6", "7", "8"
        };

        saveDataScript.SaveNewDeck(cards);
    }
}
