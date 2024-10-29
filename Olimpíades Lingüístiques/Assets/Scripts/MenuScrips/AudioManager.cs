using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource voicesSource;
    [SerializeField]
    AudioSource musicSource;

    [Header("AudioClips")]
    public AudioClip backgroundMusic;
    
    public AudioClip[] easyQuestionsAudiosRow1;
    public AudioClip[] easyQuestionsAudiosRow2;

    public AudioClip[] hardQuestionsAudiosRow1;
    public AudioClip[] hardQuestionsAudiosRow2;
    public AudioClip[] hardQuestionsAudiosRow3;

    //public AudioClip settingsClip;
    //public AudioClip playEasyModeClip;
    //public AudioClip helpClip;
    //public AudioClip modeNotEnabledClip;
    public AudioClip volumeChangedAudio;
    public AudioClip exitClip;
    public AudioClip correcteClip;
    public AudioClip ErroniClip;

    public AudioClip firstPositionClip;
    public AudioClip secondPositionClip;
    public AudioClip thirdPositionClip;

    private void Awake()
    {
        if (GameController.GetGameController().audioManager == null)
        {
            GameController.GetGameController().audioManager = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void SetVolumes(float voicesVolume, float musicVolume)
    {
        voicesSource.volume = voicesVolume;
        musicSource.volume = musicVolume;
    }

    public void PlayAudioCLip(AudioClip audioClip)
    {
        if (GameController.GetGameController().reducedVisibilityIsActive)
        {
            voicesSource.clip = audioClip;
            voicesSource.Play();
        }
    }
}
