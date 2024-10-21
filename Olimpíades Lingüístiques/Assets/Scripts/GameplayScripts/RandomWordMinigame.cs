using System;
using System.Collections;
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
    GameObject buttonPlacingZone;
    BoxCollider2D buttonPlacingZoneCollider;
    [SerializeField]
    GameObject randomWordsButton;
    BoxCollider2D buttonCollider;

    bool wordIsCorrect;
    
    [SerializeField]
    int addedMultiplyer = 1;

    bool minigameEnabled = false;

    float randomWordTimer;
    [SerializeField]
    float timeToSelect = 3.0f;

    public void WillActivateRandomWord()
    {
        if (UnityEngine.Random.Range(0, 1) == 0)
            StartCoroutine(WaitUntilActivate());
    }

    void Start()
    {
        buttonCollider = randomWordsButton.GetComponent<BoxCollider2D>();
        buttonPlacingZoneCollider = buttonPlacingZone.GetComponent<BoxCollider2D>();
        SetRandomWords();
    }

    void Update()
    {
        if (minigameEnabled)
        {
            if (randomWordTimer >= timeToSelect)
            {
                CloseRandomWord();
            }
            else
            {
                randomWordTimer += 1.0f * Time.deltaTime;
            }
        }
    }

    private IEnumerator WaitUntilActivate()
    {
        yield return new WaitForSeconds(0.5f);

        ActivateRandomWord();
    }

    private void SetRandomWords()
    {

        string[] data = randomWordsData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        randomWords = new string[data.Length / 2, 2];
        int i = 0;

        for (int row = 0; row < data.Length / 2; row++)
        {
            for (int col = 0; col < 2; col++)
            {
                randomWords[row, col] = data[i];
                i++;
            }
        }
    }

    void ActivateRandomWord()
    {
        RandomWordSelector();

        PlaceTheButton();

        minigameEnabled = true;
    }

    void RandomWordSelector()
    {
        int randomWordRow = UnityEngine.Random.Range(0, randomWords.GetLength(0));
        while (usedRandomWordsRows.Contains(randomWordRow))
        {
            randomWordRow = UnityEngine.Random.Range(0, randomWords.GetLength(0));
        }
        usedRandomWordsRows.Add(randomWordRow);

        if (usedRandomWordsRows.Count >= randomWords.GetLength(0))
            usedRandomWordsRows.Clear();

        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            randomWordsButton.GetComponentInChildren<TMP_Text>().text = randomWords[randomWordRow, 0];

            wordIsCorrect = true;
        }
        else
        {
            randomWordsButton.GetComponentInChildren<TMP_Text>().text = randomWords[randomWordRow, 1];

            wordIsCorrect = false;
        }
    }

    void PlaceTheButton()
    {
        var buttonAxis = buttonPlacingZoneCollider.bounds;

        Vector3 worldPlacingPosition = (buttonPlacingZone.transform.position);

        float buttonXPosition = UnityEngine.Random.Range(worldPlacingPosition.x - (buttonAxis.max.x/2 + (buttonCollider.bounds.max.x/2)), worldPlacingPosition.x + (buttonAxis.max.x/2 - (buttonCollider.bounds.max.x/2)));
        float buttonYPosition = UnityEngine.Random.Range(worldPlacingPosition.y - (buttonAxis.max.y/2 + (buttonCollider.bounds.max.y/2)), worldPlacingPosition.y + (buttonAxis.max.y/2 - (buttonCollider.bounds.max.y/2)));
        Debug.Log(buttonXPosition);
        Debug.Log(buttonYPosition);

        randomWordsButton.GetComponent<RectTransform>().position = (new Vector3(buttonXPosition, buttonYPosition));
        Debug.Log(randomWordsButton.GetComponent<RectTransform>().position);

        randomWordsButton.SetActive(true);
    }

    public void ButtonPressed()
    {
        if (wordIsCorrect)
        {
            GetComponent<WordSelection>().updateMultiplier(addedMultiplyer, false);
            //hacer alguna animacion de chuli acertao
        }
        else
        {
            GetComponent<WordSelection>().updateMultiplier(0, true);
            //hacer alguna animacion de NO chuli fallao
        }

        CloseRandomWord();
    }

    void CloseRandomWord()
    {
        randomWordsButton.SetActive(false);

        minigameEnabled = false;
        randomWordTimer = 0;
    }
}
