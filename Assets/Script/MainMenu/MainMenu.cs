using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.instance.NewGame();
    }

    public void SettingMenu()
    {
        Debug.Log("Try to Change to Settings Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
