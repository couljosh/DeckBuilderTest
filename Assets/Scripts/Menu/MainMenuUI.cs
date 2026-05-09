using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenuUI : MonoBehaviour
{

    public static string PlayerUUID;

    
    public void NewUser()
    {
        //Loads Deck Builder Scene
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {

        SceneManager.LoadScene(2);

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);

    }
}

