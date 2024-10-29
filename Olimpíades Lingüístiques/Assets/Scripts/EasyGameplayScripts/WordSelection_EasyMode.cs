using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class WordSelection_EasyMode : MonoBehaviour
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

    [Header("Player Movement")]
    [SerializeField] GameObject mainCharacter;
    [SerializeField] float whenLastPositionX;
    [SerializeField] float whenMiddlePositionX;
    [SerializeField] float whenFirstPositionX;
    [SerializeField] float playerSpeed = 1;
    float whereToGo;
    int currentPosition;
    bool playerMoving = false;

    [Header("")]
    public int currentQuestionNum = 0;
    [SerializeField]
    Slider raceSlider;

    [SerializeField] GameObject endingPopUp;

    bool changeToHard = false;
    bool raceQuestionsEnded = false;

    float baseMultiplier = 1;
    int correctWordsStreak = 0;

    WordsStorage_EasyMode wordsStorageScript;

    Animation buttonsAnimator;
    [SerializeField]
    AnimationClip correctAnswerAnimation;
    [SerializeField]
    AnimationClip wrongAnswerAnimation;
    [SerializeField]
    AnimationClip correctAnswerHardAnimation;
    [SerializeField]
    AnimationClip wrongAnswerHardAnimation;

    AudioManager audioManager;

    public void updateMultiplier(int addingValue, bool retunToBase)
    {
        if (!retunToBase)
            baseMultiplier += addingValue;
        else
            baseMultiplier = 1;

        baseMultiplierText.text = "X" + baseMultiplier.ToString();
    }

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        wordsStorageScript = GetComponent<WordsStorage_EasyMode>();
        points = 0;
        pointsText.text = points.ToString();
        baseMultiplierText.text = "X" + baseMultiplier.ToString();
        buttonsAnimator = GetComponent<Animation>();
        raceSlider.maxValue = wordsStorageScript.GetMaxQuestions();
        SetRaceSlider();

        mainCharacter.transform.localPosition = new Vector3(whenMiddlePositionX, mainCharacter.transform.localPosition.y, mainCharacter.transform.localPosition.z);
        currentPosition = 2;

    }

    void Update()
    {
        if (playerMoving)
        {
            MovePlayer();
        }

    }

    public void WordSelected(int buttonPressed)
    {
        wordsStorageScript.disableButtons();

        if (currentQuestionNum < wordsStorageScript.isRaceQuestionEasy.Length)
        {
            currentQuestionNum++;
            changeToHard = !wordsStorageScript.isRaceQuestionEasy[currentQuestionNum - 1];
        }
        else
            raceQuestionsEnded = true;

        if (wordsStorageScript.GetCorrectButton() == buttonPressed)
        {
            audioManager.PlayAudioCLip(audioManager.correcteClip);

            StartCoroutine(ActivateButtonImage(true, buttonPressed));
            correctWordsStreak++;
            if (correctWordsStreak == 3)
                baseMultiplier = 2f;
            else if (correctWordsStreak == 5)
                baseMultiplier = 3;

            baseMultiplierText.text = "X" + baseMultiplier.ToString(); // mirar si lo queremos antes de sumar puntos o despues

            int pointsEarned;

            if (wordsStorageScript.isRaceQuestionEasy[currentQuestionNum - 1])
                pointsEarned = (int)(easyPointIncrease * baseMultiplier);
            else
                pointsEarned = (int)(hardPointIncrease * baseMultiplier);

            points += pointsEarned;
            pointsText.text = points.ToString();

            wordsStorageScript.ResumeAnimations(true);
            PlayerMoving();
            //sube puntos, aumenta multimplicador con x aciertos y animacion ganas con evento que lleva a cambiar palabras
        }
        else
        {
            audioManager.PlayAudioCLip(audioManager.ErroniClip);

            StartCoroutine(ActivateButtonImage(false, buttonPressed));
            correctWordsStreak = 0;
            baseMultiplier = 1;

            if (currentPosition < 3)
            {
                playerMoving = true;
                if (currentPosition == 2)
                {
                    whereToGo = whenLastPositionX;
                    currentPosition = 3;
                }
                else
                {
                    whereToGo = whenMiddlePositionX;
                    currentPosition = 2;
                }
            }

            wordsStorageScript.ResumeAnimations(false);

            // reinicia multiplicador y animacion pierdes con evento que lleva a cambiar palabras
        }


        SetRaceSlider();

    }

    private IEnumerator ActivateButtonImage(bool correctAnswer, int buttonPressed)
    {
        GameObject ButtonGO;

        if (correctAnswer)
        {
            if (wordsStorageScript.isRaceQuestionEasy[currentQuestionNum - 1])
                ButtonGO = GetComponent<WordsStorage_EasyMode>().twoButtons_Obj.transform.GetChild(buttonPressed - 1).transform.GetChild(1).gameObject;
            else
                ButtonGO = GetComponent<WordsStorage_EasyMode>().threeButtons_Obj.transform.GetChild(buttonPressed - 1).transform.GetChild(1).gameObject;
        }
        else
        {
            if (wordsStorageScript.isRaceQuestionEasy[currentQuestionNum - 1])
                ButtonGO = GetComponent<WordsStorage_EasyMode>().twoButtons_Obj.transform.GetChild(buttonPressed - 1).transform.GetChild(2).gameObject;
            else
                ButtonGO = GetComponent<WordsStorage_EasyMode>().threeButtons_Obj.transform.GetChild(buttonPressed - 1).transform.GetChild(2).gameObject;
        }

        ButtonGO.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        ButtonGO.SetActive(false);
    }

    public void PlayerMoving()
    {
        if (currentPosition > 1)
        {
            playerMoving = true;
            if (currentPosition == 2)
            {
                whereToGo = whenFirstPositionX;
                currentPosition = 1;
            }
            else
            {
                whereToGo = whenMiddlePositionX;
                currentPosition = 2;
            }
        }
    }

    public void EndRace()
    {
        PlayEndAnimations();

        if (GameController.GetGameController().reducedVisibilityIsActive)
            StartCoroutine(EndAll());
        else
            StartCoroutine(ShowScorePopUp());
    }

    private void PlayEndAnimations()
    {

        if(currentPosition == 1) //Comprovem que hagi guanyat
        {
            GameObject.Find("CagaTio").GetComponent<Animator>().SetBool("Winner", true);
            GameObject.Find("Calçot").GetComponent<Animator>().SetBool("Winner", false);

            audioManager.PlayAudioCLip(audioManager.firstPositionClip);
        }
        else
        {
            GameObject.Find("CagaTio").GetComponent<Animator>().SetBool("Winner", false);
            GameObject.Find("Calçot").GetComponent<Animator>().SetBool("Winner", true);

            if(currentPosition == 2)
                audioManager.PlayAudioCLip(audioManager.secondPositionClip);
            else
                audioManager.PlayAudioCLip(audioManager.thirdPositionClip);

        }
        GameObject.Find("Rovello").GetComponent<Animator>().SetTrigger("End");
        GameObject.Find("Calçot").GetComponent<Animator>().SetTrigger("End");
        GameObject.Find("CagaTio").GetComponent<Animator>().SetTrigger("End");

    }

    private IEnumerator EndAll()
    {
        yield return new WaitForSeconds(5.0f);

        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator ShowScorePopUp()
    {
        yield return new WaitForSeconds(4.0f);

        endingPopUp.SetActive(true);
        endingPopUp.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = points.ToString();
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

        pointsText.text = points.ToString();
    }

    private void MovePlayer()
    {

        float newX = Mathf.Lerp(mainCharacter.transform.localPosition.x, whereToGo, playerSpeed * Time.deltaTime);
        mainCharacter.transform.localPosition = new Vector3(newX, mainCharacter.transform.localPosition.y, mainCharacter.transform.localPosition.z);
        if (mainCharacter.transform.localPosition.x + 0.1 > whereToGo && mainCharacter.transform.localPosition.x - 0.1 < whereToGo)
            playerMoving = false;

    }

}
