using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject settingsPanel, achievementPanel, exit;
    public TextMeshProUGUI days;

    public void LoadMainScene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
    public void LoadSavedScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }
    public void HideSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void ShowAch()
    {
        achievementPanel.SetActive(true);
        days.text = PlayerPrefs.GetInt("TotalDays").ToString();
    }

    public void HideAch()
    {
        achievementPanel.SetActive(false);
    }

    public void exiting()
    {
        Application.Quit();
        Debug.Log("Quiting application");
    }
}
