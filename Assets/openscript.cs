
using UnityEngine;
using UnityEngine.SceneManagement;

public class openscript : MonoBehaviour
{
    public GameObject section_panel;

    public void start_button()
    {
        SceneManager.LoadScene(1);
    }

    public void exit_button()
    {
        Application.Quit();
    }

    public void find_movie_duo()
    {
        SceneManager.LoadScene(2);
    }
    public void back_button()
    {
        SceneManager.LoadScene(0);
    }
    public void normal_button()
    {
        SceneManager.LoadScene(1);
    }
    public void section()
    {
        section_panel.SetActive(true);
    }

    public void other_section()
    {
        SceneManager.LoadScene(3);
    }


}

