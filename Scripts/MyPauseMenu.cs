using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyPauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    bool paused = false;
    public GameObject notifyOkay;

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        if (!paused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
        else if (paused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        paused = true;
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    public void Okay()
    {
        notifyOkay.SetActive(false);
    }
}
