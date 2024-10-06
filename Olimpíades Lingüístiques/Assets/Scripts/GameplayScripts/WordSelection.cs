using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordSelection : MonoBehaviour
{
    [SerializeField]
    TMP_Text pointsText;
    [SerializeField]
    int points;
    [SerializeField]
    int pointIncrease;

    float pointsMultiplier = 1;
    int correctWordsStreak = 0;

    [SerializeField]
    Slider timeSlider;
    [SerializeField]
    float timeSubtract;
    [SerializeField]
    float timeIncrease;

    bool timeStop;

    WordsStorage wordsStorageScript;

    void Start()
    {
        wordsStorageScript = GetComponent<WordsStorage>();
        timeSlider.value = timeSlider.maxValue;
        points = 0;
        pointsText.text = points.ToString() + " Punts";
    }

    void Update()
    {
        if (!timeStop)
        {
            if(timeSlider.value <= timeSlider.minValue)
            {
                Debug.Log("has perdio por time");
                wordsStorageScript.disableButtons();

                //enseñar pantalla que te diga si quieres reiniciar partida o salir al menu
            }
            else
            {
                timeSlider.value -= 1 * Time.deltaTime;
            }
        }
    }

    public void WordSelected(int buttonPressed)
    {
        timeStop = true;
        wordsStorageScript.disableButtons();

        if (wordsStorageScript.GetCorrectButton() == buttonPressed)
        {
            Debug.Log("tt acertao");

            correctWordsStreak++;
            if (correctWordsStreak == 3)
                pointsMultiplier = 1.5f;
            else if (correctWordsStreak == 6)
                pointsMultiplier = 2;

            points = (int)(points + pointIncrease * pointsMultiplier);
            pointsText.text = points.ToString() + " Punts";


            if ((timeSlider.value += timeIncrease) > timeSlider.maxValue)
                timeSlider.value = timeSlider.maxValue;
            else
                timeSlider.value += timeIncrease;
            //sube tiempo, puntos, aumenta multimplicador con x aciertos y animacion ganas con evento que lleva a cambiar palabras
            // si has superado x puntos o x palabras acertadas, pasar a dificiles
        }
        else
        {
            Debug.Log("has perdio");

            correctWordsStreak = 0;
            pointsMultiplier = 1;
            // reinicia multiplicador y animacion pierdes con evento que lleva a cambiar palabras
        }
    }
}
