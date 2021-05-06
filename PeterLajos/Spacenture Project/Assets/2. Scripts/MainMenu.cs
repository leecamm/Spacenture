using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        //Application.Quit(); // This line is commented, because of the WebGL build
        CoinTextScript.coinAmount = 0;
        SpeedStarTextScript.starAmount = 0;
        CounterForShootingParts.collectedPartsAmount = 0;
        Time.timeScale = 1f;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        CoinTextScript.coinAmount = 0;
        SpeedStarTextScript.starAmount = 0;
        CounterForShootingParts.collectedPartsAmount = 0;
        Time.timeScale = 1f;
    }
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
        CoinTextScript.coinAmount = 0;
        SpeedStarTextScript.starAmount = 0;
        CounterForShootingParts.collectedPartsAmount = 0;
    }
}
