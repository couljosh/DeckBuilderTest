using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    public static string PlayerUUID;
    private const string UUID_KEY = "playerUUID";

    public Button continueButton;

    private void Awake()
    {

        if (PlayerPrefs.HasKey(UUID_KEY))
        {
            continueButton.gameObject.SetActive(true);
            PlayerUUID = PlayerPrefs.GetString(UUID_KEY);

        }
        else
        {
            continueButton.gameObject.SetActive(false);

        }

        print(UUID_KEY);

    }

    public void NewUser()
    {
        //Generates UUID
        string UUID = Guid.NewGuid().ToString();

        //Saves UUID into PlayerPrefs
        PlayerPrefs.SetString(UUID_KEY, PlayerUUID);
        PlayerPrefs.Save();
        print(UUID_KEY);

        //Loads Deck Builder Scene
        SceneManager.LoadScene(1);

    }

    public void Continue()
    {
        //check playerprefs for an exsisting UUID
        if (PlayerPrefs.HasKey(UUID_KEY))
        {
            PlayerUUID = PlayerPrefs.GetString(UUID_KEY);
            print(PlayerUUID);

            //If UUID exsits, load Deck Viewer Scene
            SceneManager.LoadScene(2);
        }
        else
        {
            print("No player UUID exists");
        }

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void Update()
    {
        //To ensure functionality is correct when no UUID exists
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
          //  PlayerPrefs.DeleteAll();
        //}
    }
}

