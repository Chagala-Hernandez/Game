using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuGameController : MonoBehaviour
{
    public static MenuGameController menuGameController;
    public GameObject menuUI;

    void Awake()
    {
        if(MenuGameController.menuGameController == null)
        {
            MenuGameController.menuGameController = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
            
    }

    public void Pause()
    {
        menuUI.SetActive(false);
        
        MainMenuController.mainMenuController.canvas.SetActive(true);
        MainMenuController.mainMenuController.menuUI.SetActive(false);
        MainMenuController.mainMenuController.optionsUI.SetActive(true);
        MainMenuController.mainMenuController.backGameButton.SetActive(true);

        Time.timeScale = 0f;

        MainMenuController.Vibration();
    }

    public static void Resume()
    {
        MenuGameController.menuGameController.menuUI.SetActive(true);
        MainMenuController.mainMenuController.canvas.SetActive(false);

        Time.timeScale = 1f;

        MainMenuController.Vibration();
    }

    public static void Menu()
    {
        MenuGameController.menuGameController.menuUI.SetActive(true);
        MainMenuController.mainMenuController.canvas.SetActive(false);

        MainMenuController.Vibration();
    }

}
