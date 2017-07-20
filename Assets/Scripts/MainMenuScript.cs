using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("SceneTest");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
