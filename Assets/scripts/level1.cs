using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class level1 : MonoBehaviour {

    public static bool isPaused;
    private static GameObject PauseUI;
    [SerializeField]
    private Text txt;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "gameOver")
        {
            txt.text = PlayerPrefs.GetFloat("score").ToString();
        }
        try
        {
            PauseUI = GameObject.FindGameObjectWithTag("PauseInterface");
            PauseUI.GetComponent<Canvas>().enabled = false;
        }
        catch
        {}
        
    }

    
    public static void PauseGame()
    {
        try
        {
            GameObject.FindGameObjectWithTag("pauseIcon").GetComponent<Button>().enabled = false;
            GameObject.FindGameObjectWithTag("snakeHead").GetComponent<snakeMovement>().musicSource.Pause();
            Time.timeScale = 0;
            isPaused = true;
            PauseUI.GetComponent<Canvas>().enabled = true;
        }
        catch { }
    }
    public void Pause()
    {
        level1.PauseGame();
    }


    public static void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        PauseUI.GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("snakeHead").GetComponent<snakeMovement>().musicSource.UnPause();
        GameObject.FindGameObjectWithTag("pauseIcon").GetComponent<Button>().enabled = true;
    }

    public void Resume()
    {
        level1.ResumeGame();
    }



    public void LoadLevel()
    {
        SceneManager.LoadScene("snake3D");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("mainMenuAz");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
