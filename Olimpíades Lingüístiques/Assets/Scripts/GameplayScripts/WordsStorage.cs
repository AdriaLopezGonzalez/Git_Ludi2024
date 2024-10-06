using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordsStorage : MonoBehaviour
{
    [SerializeField]
    TextAsset easyQuestionsData;

    [SerializeField]
    TextAsset hardQuestionsData;

    string[,] easyQuestions;

    string[,] hardQuestions;

    [SerializeField]
    Button leftButton;
    [SerializeField]
    Button rightButton;

    int correctButton;

    public int GetCorrectButton()
    {
        return correctButton;
    }

    public void disableButtons()
    {
        leftButton.interactable = false;
        rightButton.interactable = false;
    }
    public void enableButtons()
    {
        leftButton.interactable = true;
        rightButton.interactable = true;
    }

    void Start()
    {
        SetEasyQuestions();
        //SetHardQuestions();
        EasyRandomWordSelector();
    }

    private void SetHardQuestions()
    {
        string[] data = hardQuestionsData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        hardQuestions = new string[data.Length / 3, 3];
        int i = 0;

        for (int row = 0; row < data.Length / 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                hardQuestions[row, col] = data[i];
                i++;
            }
        }
    }

    private void SetEasyQuestions()
    {
        
        string[] data = easyQuestionsData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        easyQuestions = new string[data.Length / 2, 2];
        int i = 0;

        for (int row = 0; row < data.Length/2; row++)
        {
            for (int col = 0; col < 2; col++)
            {
                easyQuestions[row, col] = data[i];
                i++;
            }
        }
    }

    private void EasyRandomWordSelector()
    {

        int randomQuestionNum = UnityEngine.Random.Range(0, easyQuestions.GetLength(0));

        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            leftButton.GetComponentInChildren<TMP_Text>().text = easyQuestions[randomQuestionNum, 0];
            rightButton.GetComponentInChildren<TMP_Text>().text = easyQuestions[randomQuestionNum, 1];

            correctButton = 1;
        }
        else
        {
            leftButton.GetComponentInChildren<TMP_Text>().text = easyQuestions[randomQuestionNum, 1];
            rightButton.GetComponentInChildren<TMP_Text>().text = easyQuestions[randomQuestionNum, 0];

            correctButton = 2;
        }

    }
}
