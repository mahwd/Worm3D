using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text highScore;
    private void Start()
    {
        highScore.text = PlayerPrefs.GetFloat("HighScore",0).ToString();
    }
    static float hs;
    public static void OnGameOver(snakeMovement snake)
    {
        hs = PlayerPrefs.GetFloat("HighScore",0);
        if (hs < snake.score)
        {
            PlayerPrefs.SetFloat("HighScore",snake.score);
        }
        PlayerPrefs.SetFloat("score", snake.score);
        snake.score = 0;
        SceneManager.LoadScene("gameOver");
    }


}
