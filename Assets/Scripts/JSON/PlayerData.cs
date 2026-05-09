using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerUUID;
    public DeckData[] decks;

}


[System.Serializable]
public class DeckData 
{
    public string[] cards;

}

