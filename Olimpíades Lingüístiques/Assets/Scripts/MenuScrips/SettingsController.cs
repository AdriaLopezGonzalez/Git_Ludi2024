using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField]
    Slider voicesSlider;
    [SerializeField]
    Slider musicSlider;

    float voicesVolume;
    float musicVolume;

    [SerializeField]
    GameObject daltonismSelectedImage;

    bool daltonismIsActive = false;

    void Start()
    {
        voicesVolume = GameController.GetGameController().VoicesVolume;
        voicesSlider.value = voicesVolume;
        musicVolume = GameController.GetGameController().musicVolume;
        musicSlider.value = musicVolume;

        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().SetVolumes( voicesVolume, musicVolume);

        daltonismIsActive = GameController.GetGameController().daltonismIsActive;
        if (daltonismIsActive)
            daltonismSelectedImage.SetActive(true);
    }

    public void VoicesVolumeLevel(float newVoicesVolume)
    {
        voicesVolume = newVoicesVolume;

        GameController.GetGameController().VoicesVolume = voicesVolume;

        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().SetVolumes(voicesVolume, musicVolume);
    }

    public void MusicVolumeLevel(float newMusicVolume)
    {
        musicVolume = newMusicVolume;

        GameController.GetGameController().musicVolume = musicVolume;

        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().SetVolumes(voicesVolume, musicVolume);
    }

    public void buttonDaltonismSelected()
    {
        if (daltonismIsActive)
        {
            daltonismIsActive = false;
            daltonismSelectedImage.SetActive(false);
        }
        else
        {
            daltonismIsActive = true;
            daltonismSelectedImage.SetActive(true);
        }

        GameController.GetGameController().daltonismIsActive = daltonismIsActive;
    }
}
