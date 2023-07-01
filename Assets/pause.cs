using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject pause_panel;
   

    public void mainmenu()
    {
        SceneManager.LoadScene(0);
        pause_panel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void exitPause_button()
    {
        Application.Quit();
        Time.timeScale = 1.0f;
    }

    public void PauseButton()
    {
        Time.timeScale = 0.0f;
        pause_panel.SetActive(true);

    }

    public void ResumeButton()
    {
        pause_panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
