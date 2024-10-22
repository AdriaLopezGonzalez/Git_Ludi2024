using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private void Start()
    {
        GameController.GetGameController();
    }

    public void StartButtonPressed(bool easyMode)
    {
        if (easyMode)
            SceneManager.LoadScene("EasyGameplayScene");
        else
            SceneManager.LoadScene("GameplayScene");
    }

    public void SettingsButtonPressed()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ExitButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
