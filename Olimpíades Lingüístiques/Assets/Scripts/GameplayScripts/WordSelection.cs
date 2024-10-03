using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSelection : MonoBehaviour
{
    [SerializeField]
    Slider timeSlider;
    [SerializeField]
    float timeSubtract;
    [SerializeField]
    float timeIncrease;

    WordsStorage wordsStorageScript;

    void Start()
    {
        wordsStorageScript = GetComponent<WordsStorage>();
    }

    void Update()
    {
        
    }

    public void WordSelected(bool leftButton)
    {
        if (wordsStorageScript.getIfLeftCorrect())
        {
            if (leftButton)
            {
                //CorrectAnswer(AddPonits&AddTime&ChangeWords)
            }
            else
            {
                //WrongAnswer(ChangeWords)
            }
        }
        else
        {
            if (leftButton)
            {
                //WrongAnswer(ChangeWords)
            }
            else
            {
                //CorrectAnswer(AddPonits&AddTime&ChangeWords)
            }
        }
    }
}
