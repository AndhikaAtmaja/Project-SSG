using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("Config MainMenu")]
    public string music;
    public GameObject mainMenuUI;
    public GameObject settingsUI;

    private bool isSettingOpen;

    private void Start()
    {
        PlayAudioMainMenu();
    }

    private void PlayAudioMainMenu()
    {
        if (string.IsNullOrEmpty(music))
            return;
        MusicManager.instance.PlayMusic(music);
    }

    public void StartGame()
    {
        GameManager.instance.NewGame();
    }

    public void SettingMenu()
    {
        if (!isSettingOpen)
            isSettingOpen = true;
        else
            isSettingOpen = false;

        mainMenuUI.SetActive(!isSettingOpen);
        settingsUI.SetActive(isSettingOpen);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
