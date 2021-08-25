using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController mainMenuController;
    public GameObject canvas;
    public GameObject menuUI;
    public GameObject optionsUI;
    public GameObject backGameButton;
    public Toggle vibrationToggle;

    public static bool vibration = true;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if(MainMenuController.mainMenuController == null)
        {
            MainMenuController.mainMenuController = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        vibrationToggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(vibrationToggle);
        });
    }

    void ToggleValueChanged(Toggle change)
    {
        vibration = vibrationToggle.isOn;

        Vibration();
    }

    public void Play()
    {
        canvas.SetActive(false);

        if(MenuGameController.menuGameController != null)
            MenuGameController.menuGameController.menuUI.SetActive(true);
        
        SceneManager.LoadScene("Game");
        ScriptAudio.Pause();
        
        Vibration();
    }

    public void Options()
    {
        menuUI.SetActive(false);
        optionsUI.SetActive(true);
        backGameButton.SetActive(false);

        Vibration();
    }

    public void Quit()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }

    public void BackUI(GameObject panelUI)
    {
        menuUI.SetActive(false);
        optionsUI.SetActive(false);

        panelUI.SetActive(true);
        SceneManager.LoadScene("MainMenuScene");
        ScriptAudio.Play();

        Vibration();
    }

    public void BackGame()
    {
        MenuGameController.Resume();
    }

    public static void Vibration()
    {
        if(vibration == true)
        {
            Handheld.Vibrate();
        }
    }
}
