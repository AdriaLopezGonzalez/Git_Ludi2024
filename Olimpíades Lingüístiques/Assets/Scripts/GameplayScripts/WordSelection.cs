using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordSelection : MonoBehaviour
{
    [SerializeField]
    TMP_Text pointsText;
    int points;
    [SerializeField]
    int pointIncrease;
    [SerializeField]
    int pointsToChangeDiff;

    bool changeToHard = false;

    float pointsMultiplier = 1;
    int correctWordsStreak = 0;

    [SerializeField]
    Slider timeSlider;
    [SerializeField]
    float timeSubtract;
    [SerializeField]
    float timeIncrease_WordAnswered;
    [SerializeField]
    float timeSubstract_WordMissed;

    bool timeStop;

    WordsStorage wordsStorageScript;

    Animation buttonsAnimator;
    [SerializeField]
    AnimationClip correctAnswerAnimation;
    [SerializeField]
    AnimationClip wrongAnswerAnimation;
    [SerializeField]
    AnimationClip correctAnswerHardAnimation;
    [SerializeField]
    AnimationClip wrongAnswerHardAnimation;


    public void ResumeTime()
    {
        timeStop = false;
    }

    void Start()
    {
        wordsStorageScript = GetComponent<WordsStorage>();
        timeSlider.value = timeSlider.maxValue;
        timeSlider.enabled = false;
        points = 0;
        pointsText.text = points.ToString() + " Punts";
        buttonsAnimator = GetComponent<Animation>();
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
                timeSlider.value -= timeSubtract * Time.deltaTime;
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


            if ((timeSlider.value += timeIncrease_WordAnswered) > timeSlider.maxValue)
                timeSlider.value = timeSlider.maxValue;
            else
                timeSlider.value += timeIncrease_WordAnswered;

            if ((points >= pointsToChangeDiff) && !changeToHard)
            {

                changeToHard = true;
            }

            PlayButtonsAnimation(true);
            //sube tiempo, puntos, aumenta multimplicador con x aciertos y animacion ganas con evento que lleva a cambiar palabras
            // si has superado x puntos o x palabras acertadas, pasar a dificiles
        }
        else
        {
            Debug.Log("has perdio");

            correctWordsStreak = 0;
            pointsMultiplier = 1;

            if ((timeSlider.value -= timeSubstract_WordMissed) < timeSlider.minValue)
                timeSlider.value = timeSlider.minValue;
            else
                timeSlider.value -= timeSubstract_WordMissed;

            PlayButtonsAnimation(false);
            // reinicia multiplicador y animacion pierdes con evento que lleva a cambiar palabras
        }
    }

    void PlayButtonsAnimation(bool correctAnswer)
    {
        if (changeToHard)
        {

            if (correctAnswer)
                buttonsAnimator.Play(correctAnswerHardAnimation.name);
            else
                buttonsAnimator.Play(wrongAnswerHardAnimation.name);
        }
        else
        {
            if (correctAnswer)
                buttonsAnimator.Play(correctAnswerAnimation.name);
            else
                buttonsAnimator.Play(wrongAnswerAnimation.name);
        }
    }
}
