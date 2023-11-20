using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuCode : MonoBehaviour
{
    public GameObject mainMenuFirstButton, firstConfirmCloseButton, firtstCloseMenuButton, infoBackButton;

    private void Start()
    {
        //clear seleceted object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void InfoBackButton()
    {
        //clear seleceted object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(infoBackButton);
    }

    public void CreditsButton()
    {
        //clear seleceted object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(firtstCloseMenuButton);
    }

    public void OpenExitMenu()
    {
        //clear seleceted object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(firstConfirmCloseButton);
    }

    public void BackToMenu()
    {
        //clear seleceted object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
