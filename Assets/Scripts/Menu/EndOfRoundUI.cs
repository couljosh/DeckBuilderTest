using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfRoundUI : MonoBehaviour
{
    public void SaveDeck()
    {
        SceneManager.LoadScene(0);
    }

    public void DiscardDeck()
    {
        SceneManager.LoadScene(1);
    }
}
