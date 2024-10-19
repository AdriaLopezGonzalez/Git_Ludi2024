using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomWordMinigame : MonoBehaviour
{
    [SerializeField]
    TextAsset randomWordsData;

    string[,] randomWords;
    
    List<int> usedRandomWordsRows = new List<int>();

    [SerializeField]
    BoxCollider2D buttonPlacedZone;
    [SerializeField]
    Button randomWordsButton;
    
    [SerializeField]
    int wordPressedMultiplyer = 1;

    bool minigameEnabled = false;

    float randomWordTimer;
    [SerializeField]
    float timeToSelect = 3.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (minigameEnabled)
        {
            if (randomWordTimer >= timeToSelect)
            {
                RandomWordTimeOver();
            }
            else
            {
                randomWordTimer += 1.0f * Time.deltaTime;
            }
        }
    }

    void RandomWordTimeOver()
    {

    }

    public void WillActivateRandomWord()
    {
        if (UnityEngine.Random.Range(0, 2) == 0)
            ActivateRandomWord();
    }

    void ActivateRandomWord()
    {

    }
}
