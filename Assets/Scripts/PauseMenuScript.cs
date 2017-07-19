using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {

    [SerializeField] GameObject PauseUI;
    private bool Paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Paused = !Paused;
        }

        if (Paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!Paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void Resume()
    {
        Paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SceneTest");
    }

    public void MainMenu()
    {
        //SceneManager.LoadScene("MainMenu");
        Paused = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
