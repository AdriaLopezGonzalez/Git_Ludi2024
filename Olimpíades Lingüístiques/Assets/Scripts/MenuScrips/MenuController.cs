using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    bool reducedVisibilityEnabled;
    [SerializeField]
    GameObject reducedVisibilitySelectedImage;

    private void Start()
    {
        GameController.GetGameController();

        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            reducedVisibilityEnabled = GameController.GetGameController().reducedVisibilityIsActive;
            if (reducedVisibilityEnabled)
                reducedVisibilitySelectedImage.SetActive(true);
        }
    }

    public void StartButtonPressed(bool easyMode)
    {
        if (easyMode)
            SceneManager.LoadScene("EasyGameplayScene");
        else
        {
            if(!GameController.GetGameController().reducedVisibilityIsActive)
                SceneManager.LoadScene("GameplayScene");
        }
    }

    public void SettingsButtonPressed()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ExitButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void AudioHelpPressed()
    {
        if (reducedVisibilityEnabled)
        {
            reducedVisibilityEnabled = false;
            reducedVisibilitySelectedImage.SetActive(false);
        }
        else
        {
            reducedVisibilityEnabled = true;
            reducedVisibilitySelectedImage.SetActive(true);
        }

        GameController.GetGameController().reducedVisibilityIsActive = reducedVisibilityEnabled;
    }

    public void OverTheButtonSound(AudioClip audioClip)
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlayAudioCLip(audioClip);
    }
}
