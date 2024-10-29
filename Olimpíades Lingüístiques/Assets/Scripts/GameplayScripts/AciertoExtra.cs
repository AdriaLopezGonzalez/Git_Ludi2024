using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AciertoExtra : MonoBehaviour
{
    Slider slider;
    WordSelection wordSelection;

    public float timeIncrease;
    public int greatMultiplierMin;
    public int greatMultiplierMax;
    public int normalMultiplierMin;
    public int normalMultiplierMax;

    public int greatMultiplierMult;
    public int normalMultiplierMult;

    bool ongoing = false;

    int pointsEarnedLastRound;

    // Start is called before the first frame update
    void Start()
    {
        // LA PRIMERA VEZ NO SALE???
        slider = GetComponent<Slider>();
        wordSelection = GameObject.Find("Canvas").GetComponent<WordSelection>();
        slider.value = slider.minValue;
        slider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //darle al tiempo y llega al max value acabar sin na
        if (ongoing)
        {
            slider.value += timeIncrease * Time.deltaTime;
            if (Input.GetMouseButtonDown(0))
                OnClick();
        }

        if (slider.value >= slider.maxValue)
            GoBack(0);


    }

    public void AciertoAchieved(int pointsEarned)
    {
        pointsEarnedLastRound = pointsEarned;
        ongoing = true;

    }

    public void OnClick()
    {

        if (slider.value >greatMultiplierMin && slider.value < greatMultiplierMax)
        {
            //sumar multipliers
            GoBack((pointsEarnedLastRound * greatMultiplierMult) - pointsEarnedLastRound);
        }
        else if (slider.value > normalMultiplierMin && slider.value < normalMultiplierMax)
        {
            //sumar multipliers
            GoBack((pointsEarnedLastRound*normalMultiplierMult)-pointsEarnedLastRound);
        }
        else
        {
            GoBack(0);
        }

        if(FindAnyObjectByType<WordSelection>().currentQuestionNum < 10)
            GetComponentInParent<RandomWordMinigame>().WillActivateRandomWord();
    }

    private void GoBack(int newPoints)
    {

        wordSelection.AddPoints(newPoints);

        ongoing = false;
        slider.value = slider.minValue;

        slider.gameObject.SetActive(false);

        GetComponentInParent<WordsStorage>().ResumeAnimations(true);
        GetComponentInParent<WordSelection>().PlayerMoving();

        if(GetComponentInParent<WordSelection>().currentQuestionNum < 10)
            GetComponentInParent<RandomWordMinigame>().WillActivateRandomWord();
    }

}
