using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// was having error that PauseMenu already exist so changed name to MpauseMenu
public class MPauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    bool paused= false;

    private void Update()
    {
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
}
