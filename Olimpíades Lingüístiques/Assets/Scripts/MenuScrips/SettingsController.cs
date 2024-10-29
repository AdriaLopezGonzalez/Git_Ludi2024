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

    float voicesVolume = 0.5f;
    float musicVolume = 0.5f;

    [SerializeField]
    GameObject daltonismSelectedImage;

    bool daltonismIsActive = false;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        voicesVolume = GameController.GetGameController().VoicesVolume;
        voicesSlider.value = voicesVolume;
        musicVolume = GameController.GetGameController().musicVolume;
        musicSlider.value = musicVolume;

        audioManager.SetVolumes( voicesVolume, musicVolume);

        daltonismIsActive = GameController.GetGameController().daltonismIsActive;
        if (daltonismIsActive)
            daltonismSelectedImage.SetActive(true);
    }

    public void VoicesVolumeLevel(float newVoicesVolume)
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlayAudioCLip(audioManager.volumeChangedAudio);

        voicesVolume = newVoicesVolume;

        GameController.GetGameController().VoicesVolume = voicesVolume;

        audioManager.SetVolumes(voicesVolume, musicVolume);
    }

    public void MusicVolumeLevel(float newMusicVolume)
    {
        musicVolume = newMusicVolume;

        GameController.GetGameController().musicVolume = musicVolume;

        audioManager.SetVolumes(voicesVolume, musicVolume);
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
