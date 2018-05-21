using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteristicsMenu : MonoBehaviour {

    public bool isPaused = false;
    public GameObject charMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (isPaused)
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
        charMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Pause()
    {
        charMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
}
