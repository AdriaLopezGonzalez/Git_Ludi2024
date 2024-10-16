using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordsStorage : MonoBehaviour
{
    [SerializeField]
    TextAsset easyQuestionsData;

    [SerializeField]
    TextAsset hardQuestionsData;

    [SerializeField]
    GameObject twoButtons_Obj;
    [SerializeField]
    GameObject threeButtons_Obj;

    string[,] easyQuestions;
    string[,] hardQuestions;

    [Header("Carrera")]
    int easyQuestionsCounter = 0;
    int hardQuestionsCounter = 0;
    [SerializeField]
    int easyQuestionsNumber = 5;
    [SerializeField]
    int hardQuestionsNumber = 5;
    public bool[] isRaceQuestionEasy;

    List<int> usedEasyRows = new List<int>();
    List<int> usedHardRows = new List<int>();

    [SerializeField]
    Button leftButton_EasyWords;
    [SerializeField]
    Button rightButton_EasyWords;

    [SerializeField]
    Button leftButton_HardWords;
    [SerializeField]
    Button middleButton_HardWords;
    [SerializeField]
    Button rightButton_HardWords;

    int correctButton;

    [Header("Palabra Random")]
    [SerializeField]
    TextAsset randomWordsData;
    string[,] randomWords;
    List<int> usedRandomWordsRows = new List<int>();
    [SerializeField]
    Button randomWordsButton;
    [SerializeField]
    int wordPressedMultiplyer = 1;

    public int GetCorrectButton()
    {
        return correctButton;
    }

    public void disableButtons()
    {
        leftButton_EasyWords.interactable = false;
        rightButton_EasyWords.interactable = false;
        leftButton_HardWords.interactable = false;
        middleButton_HardWords.interactable = false;
        rightButton_HardWords.interactable = false;
    }
    public void enableButtons()
    {
        leftButton_EasyWords.interactable = true;
        rightButton_EasyWords.interactable = true;
        leftButton_HardWords.interactable = true;
        middleButton_HardWords.interactable = true;
        rightButton_HardWords.interactable = true;
    }

    void Start()
    {
        SetEasyQuestions();
        SetHardQuestions();
        SetRaceQuestionsType();
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

        for (int row = 0; row < data.Length / 2; row++)
        {
            for (int col = 0; col < 2; col++)
            {
                easyQuestions[row, col] = data[i];
                i++;
            }
        }
    }

    public void SetRaceQuestionsType()
    {
        isRaceQuestionEasy = new bool[(easyQuestionsNumber + hardQuestionsNumber)];

        for (int i = 0; i < isRaceQuestionEasy.Length; i++)
        {
            if (i == 0)
            {
                easyQuestionsCounter++;
                isRaceQuestionEasy[i] = true;
            }
            else if (i == 9)
            {
                hardQuestionsCounter++;
                isRaceQuestionEasy[i] = false;
            }
            else
            {
                if ((UnityEngine.Random.Range(0, 2) == 0) || hardQuestionsCounter == 4)
                {
                    easyQuestionsCounter++;
                    isRaceQuestionEasy[i] = true;
                }
                else
                {
                    hardQuestionsCounter++;
                    isRaceQuestionEasy[i] = false;
                }
            }
        }
    }

    /*public bool EasyQuestionPlaced()
    {
        if (easyQuestionsCounter >= maxCounterValue)
            return false;
        else if (hardQuestionsCounter >= maxCounterValue)
            return true;
        else
        {
            if (UnityEngine.Random.Range(0, 2) == 0)
                return true;
            else
                return false;
        }
    }*/

    private void EasyRandomWordSelector()
    {

        int randomQuestionRow = UnityEngine.Random.Range(0, easyQuestions.GetLength(0));
        while (usedEasyRows.Contains(randomQuestionRow))
        {
            randomQuestionRow = UnityEngine.Random.Range(0, easyQuestions.GetLength(0));
        }
        usedEasyRows.Add(randomQuestionRow);

        if (usedEasyRows.Count >= easyQuestions.GetLength(0))
            usedEasyRows.Clear();

        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            leftButton_EasyWords.GetComponentInChildren<TMP_Text>().text = easyQuestions[randomQuestionRow, 0];
            rightButton_EasyWords.GetComponentInChildren<TMP_Text>().text = easyQuestions[randomQuestionRow, 1];

            correctButton = 1;
        }
        else
        {
            leftButton_EasyWords.GetComponentInChildren<TMP_Text>().text = easyQuestions[randomQuestionRow, 1];
            rightButton_EasyWords.GetComponentInChildren<TMP_Text>().text = easyQuestions[randomQuestionRow, 0];

            correctButton = 2;
        }

    }

    private void HardRandomWordSelector()
    {

        int randomQuestionRow = UnityEngine.Random.Range(0, hardQuestions.GetLength(0));
        while (usedHardRows.Contains(randomQuestionRow))
        {
            randomQuestionRow = UnityEngine.Random.Range(0, hardQuestions.GetLength(0));
        }
        usedHardRows.Add(randomQuestionRow);

        if (usedHardRows.Count >= hardQuestions.GetLength(0))
            usedHardRows.Clear();

        int randomQuestionColumn = UnityEngine.Random.Range(0, 3);
        if (randomQuestionColumn == 0)
        {
            leftButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 0];
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                middleButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 1];
                rightButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 2];
            }
            else
            {
                middleButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 2];
                rightButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 1];
            }

            correctButton = 1;
        }
        else if (randomQuestionColumn == 1)
        {
            middleButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 0];
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                leftButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 1];
                rightButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 2];
            }
            else
            {
                leftButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 2];
                rightButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 1];
            }

            correctButton = 2;
        }
        else
        {
            rightButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 0];
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                leftButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 1];
                middleButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 2];
            }
            else
            {
                leftButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 2];
                middleButton_HardWords.GetComponentInChildren<TMP_Text>().text = hardQuestions[randomQuestionRow, 1];
            }

            correctButton = 3;
        }

    }

    public void animationEasyEnded()
    {
        CheckActiveButtons();

        enableButtons();

        EasyRandomWordSelector();

        GetComponent<WordSelection>().ResumeTime();
    }

    public void animationHardEnded()
    {
        CheckActiveButtons();

        enableButtons();

        HardRandomWordSelector();

        GetComponent<WordSelection>().ResumeTime();
    }
    
    public void CheckActiveButtons()
    {
        if (isRaceQuestionEasy[GetComponent<WordSelection>().currentQuestionNum])
        {
            twoButtons_Obj.SetActive(true);
            threeButtons_Obj.SetActive(false);
        }
        else
        {
            twoButtons_Obj.SetActive(false);
            threeButtons_Obj.SetActive(true);
        }
    }

    public int GetMaxQuestions()
    {
        return hardQuestionsNumber + easyQuestionsNumber;
    }
}
