using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordSelection : MonoBehaviour
{
    [SerializeField]
    TMP_Text pointsText;
    [SerializeField]
    TMP_Text baseMultiplierText;
    int points;
    [SerializeField]
    int easyPointIncrease;
    [SerializeField]
    int hardPointIncrease;

    public int currentQuestionNum = 0;
    [SerializeField]
    Slider raceSlider;

    [SerializeField]
    AciertoExtra minijuegoAcierto;
    int minijuegoMultiplier;

    bool changeToHard = false;
    bool raceQuestionsEnded = false;

    float baseMultiplier = 1;
    int correctWordsStreak = 0;

    [SerializeField]
    Slider timeSlider;
    [SerializeField]
    float timeSubtract;


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


    public void StartTimer()
    {
        timeSlider.value = timeSlider.maxValue;
        timeStop = false;
    }
    private void StopTimer()
    {
        timeStop = true;
    }

    void Start()
    {
        wordsStorageScript = GetComponent<WordsStorage>();
        timeSlider.value = timeSlider.maxValue;
        timeSlider.enabled = false;
        points = 0;
        pointsText.text = points.ToString() + " Punts";
        baseMultiplierText.text = "X" + baseMultiplier.ToString();
        buttonsAnimator = GetComponent<Animation>();
        raceSlider.maxValue = wordsStorageScript.GetMaxQuestions();
        SetRaceSlider();
    }

    void Update()
    {

        if (!timeStop)
        {
            if (timeSlider.value <= timeSlider.minValue)
            {
                QuestionTimeOver();
            }
            else
            {
                timeSlider.value -= timeSubtract * Time.deltaTime;
            }
        }

    }

    public void WordSelected(int buttonPressed)
    {
        StopTimer();
        wordsStorageScript.disableButtons();

        if (currentQuestionNum < wordsStorageScript.isRaceQuestionEasy.Length - 1)
        {
            currentQuestionNum++;
            changeToHard = !wordsStorageScript.isRaceQuestionEasy[currentQuestionNum];
        }
        else
            raceQuestionsEnded = true;

        if (wordsStorageScript.GetCorrectButton() == buttonPressed)
        {
            Debug.Log("tt acertao");

            correctWordsStreak++;
            if (correctWordsStreak == 3)
                baseMultiplier = 2f;
            else if (correctWordsStreak == 5)
                baseMultiplier = 3;

            baseMultiplierText.text = "X" + baseMultiplier.ToString(); // mirar si lo queremos antes de sumar puntos o despues

            int pointsEarned;

            if (wordsStorageScript.isRaceQuestionEasy[currentQuestionNum - 1])
                pointsEarned = (int)(points + easyPointIncrease * baseMultiplier);
            else
                pointsEarned = (int)(points + hardPointIncrease * baseMultiplier);

            points += pointsEarned;
            pointsText.text = points.ToString() + " Punts";

            minijuegoAcierto.gameObject.SetActive(true);
            minijuegoAcierto.AciertoAchieved(pointsEarned);

            if (raceQuestionsEnded)
                EndRace();
            else
                PlayButtonsAnimation(true);
            //sube puntos, aumenta multimplicador con x aciertos y animacion ganas con evento que lleva a cambiar palabras
        }
        else
        {
            Debug.Log("has perdio");

            correctWordsStreak = 0;
            baseMultiplier = 1;

            if (raceQuestionsEnded)
                EndRace();
            else
                PlayButtonsAnimation(false);
            // reinicia multiplicador y animacion pierdes con evento que lleva a cambiar palabras
        }


        SetRaceSlider();

    }

    private void QuestionTimeOver()
    {
        StopTimer();
        wordsStorageScript.disableButtons();

        if (currentQuestionNum < wordsStorageScript.isRaceQuestionEasy.Length - 1)
        {
            currentQuestionNum++;
            changeToHard = !wordsStorageScript.isRaceQuestionEasy[currentQuestionNum];
        }
        else
            raceQuestionsEnded = true;

        Debug.Log("has perdio");

        correctWordsStreak = 0;
        baseMultiplier = 1;

        if (raceQuestionsEnded)
            EndRace();
        else
            PlayButtonsAnimation(false);

        SetRaceSlider();
    }

    private void EndRace()
    {
        //SE ACABA LA PARTIDA, hemos llegado meta
        // animacion de llegar a meta y paramos preguntas
        // despues ponemos pa poner nombre a puntuacion
    }

    private void SetRaceSlider()
    {
        if (raceQuestionsEnded)
            raceSlider.value = raceSlider.maxValue;
        else
            raceSlider.value = currentQuestionNum;
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

    public int GetPoints()
    {
        return points;
    }

    public void AddPoints(int newPoints)
    {
        points += newPoints;

        pointsText.text = points.ToString() + " Punts";
    }
}
