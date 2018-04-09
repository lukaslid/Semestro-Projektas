using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameoIsPaused = false;


    public GameObject pauseMenuUI;

	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
        {
            if(GameoIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameoIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameoIsPaused = true;  
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void LoadSettings()
    {
        Debug.Log("Loadings settings.....");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
