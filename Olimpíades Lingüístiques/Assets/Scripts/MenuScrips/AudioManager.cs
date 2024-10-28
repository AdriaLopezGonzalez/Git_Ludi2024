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
}
