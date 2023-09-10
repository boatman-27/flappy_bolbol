using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject GameOverScreen;


    [ContextMenu("Increase Score")]
    public void AddScore(int scoretoAdd)
    {
        score += scoretoAdd;
        scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
    }
}
