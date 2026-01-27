using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{

    public void LoadMainGameScene()
    {
        SceneManager.LoadScene("MainGame");
        Debug.Log("CLick ");
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Mainmenu");
        Debug.Log("CLick ");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("CLick ");
    }
}
