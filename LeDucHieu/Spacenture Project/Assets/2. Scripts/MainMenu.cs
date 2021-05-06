using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        CoinTextScript.coinAmount = 0;
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        CoinTextScript.coinAmount = 0;
        Time.timeScale = 1f;
    }
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
