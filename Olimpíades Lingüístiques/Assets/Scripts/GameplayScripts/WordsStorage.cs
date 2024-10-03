using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordsStorage : MonoBehaviour
{
    [SerializeField]
    string[] correctWords;
    [SerializeField]
    string[] wrongWords;

    [SerializeField]
    Button leftButton;
    [SerializeField]
    Button rightButton;

    bool leftIsCorrect;

    public bool getIfLeftCorrect()
    {
        return leftIsCorrect;
    }

    void Start()
    {
        RandomWordSelector();
    }

    void Update()
    {
        
    }

    private void RandomWordSelector()
    {
        string[] leftButtonArray;
        string[] rightButtonArray;

        if (Random.Range(0, 2) == 0)
        {
            leftButtonArray = correctWords;
            rightButtonArray = wrongWords;

            leftIsCorrect = true;
        }
        else
        {
            leftButtonArray = wrongWords;
            rightButtonArray = correctWords;

            leftIsCorrect = false;
        }

        int wordNumber = Random.Range(0, leftButtonArray.Length);

        leftButton.GetComponentInChildren<TMP_Text>().text = leftButtonArray[wordNumber];
        rightButton.GetComponentInChildren<TMP_Text>().text = rightButtonArray[wordNumber];
    }
}
