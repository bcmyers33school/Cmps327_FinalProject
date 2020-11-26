using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Menu(string Menu)
    {
        SceneManager.LoadScene(Menu);
    }
    public void PlayFPP(string FPP)
    {
        SceneManager.LoadScene(FPP);
    }

    public void PlayTPP(string TPP)
    {
        SceneManager.LoadScene(TPP);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
