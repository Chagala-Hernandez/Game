using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject OptionsPanel;

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OptionsGame()
    {
        MainMenu.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
    }

    public void BackMainMenu()
    {
        MainMenu.SetActive(true);
        OptionsPanel.SetActive(false);
    }
}
