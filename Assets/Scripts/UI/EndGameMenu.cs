using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class EndGameMenu : MonoBehaviour
{
    public static EndGameMenu instance;

    public GameObject firstEndMenuButton, confirmCloseButton;
    private void Start()
    {
        instance = this;
        EndMenuAgain();
    }

    public void EndMenuAgain()
    {
        //clear seleceted object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(firstEndMenuButton);
    }

    public void OpenExitMenu()
    {
        //clear seleceted object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(confirmCloseButton);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resart()
    {
        SceneManager.LoadScene("Level 1");
    }
}
