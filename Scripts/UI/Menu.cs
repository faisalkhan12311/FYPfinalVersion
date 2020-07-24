using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
   //tracks menu on or off
   public static bool gameIsPause = false;

    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (gameIsPause)
        {
            resume();
        }
        else
        {
            pause();
        }

    }
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }
    private void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }
}
