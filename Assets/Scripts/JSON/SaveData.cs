using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class SaveData : MonoBehaviour
{

    [Header("Bin References")]
    public string Bin_ID;
    public string Api_Key;

    [Header("References")]
    public PlayerData currentData;

    //Temporary setup to test saving current deck
    public void SaveNewDeck(List<string> card_IDs)
    {
        DeckData newDeck = new DeckData();
        newDeck.cards = card_IDs.ToArray();

        if(currentData == null)
        {
            currentData = new PlayerData();
            currentData.playerUUID = PlayerPrefs.GetString("playerUUID");
            currentData.decks = new DeckData[1];
            currentData.decks[0] = newDeck;
        }
        else
        {
            List<DeckData> decks = new List<DeckData>(currentData.decks);
            decks.Add(newDeck);
            currentData.decks = decks.ToArray();
        }

        StartCoroutine(SendData(currentData));
    }

    //Test to Send to JSON Bin
    IEnumerator SendData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        string url = "https://api.jsonbin.io/v3/b/" + Bin_ID;

        UnityWebRequest request = new UnityWebRequest(url, "PUT");

        byte[] body = System.Text.Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(body);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("X-Master-Key", Api_Key);

        yield return request.SendWebRequest();

        if(request.result == UnityWebRequest.Result.Success)
        {
            print("saved");
        }
        else
        {
            print(request.error);
        }
    }

}
