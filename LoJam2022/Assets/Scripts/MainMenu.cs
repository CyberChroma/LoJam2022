using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Brandon");
    }

    public void Return()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
