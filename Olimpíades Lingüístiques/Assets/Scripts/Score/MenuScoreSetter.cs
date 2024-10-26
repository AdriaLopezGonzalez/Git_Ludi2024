using UnityEngine;
using TMPro;
using System;

public class MenuScoreSetter : MonoBehaviour
{
    ScoreKeeper scKeeper;

    [SerializeField] TMP_Text firstPlace;
    [SerializeField] TMP_Text secondPlace;
    [SerializeField] TMP_Text thirdPlace;
    [SerializeField] TMP_Text otherPlaces;

    private void Start()
    {

        scKeeper = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();

        /*
        scKeeper.EnterNewScore("GTS", 50);
        scKeeper.EnterNewScore("TET", 550);
        scKeeper.EnterNewScore("PTO", 100);
        scKeeper.EnterNewScore("FIT", 120);
        scKeeper.EnterNewScore("SOK", 90);
        scKeeper.EnterNewScore("KIK", 300);
        scKeeper.EnterNewScore("ALG", 571);
        scKeeper.EnterNewScore("JJM", 6000);
        scKeeper.EnterNewScore("PFB", 900);
        scKeeper.EnterNewScore("POP", 5);
        scKeeper.EnterNewScore("GTS", 10);
        */

        firstPlace.text = scKeeper.GetNameOnPosition(1) + " " + scKeeper.GetScoreOnPosition(1);
        secondPlace.text = scKeeper.GetNameOnPosition(2) + " " + scKeeper.GetScoreOnPosition(2);
        thirdPlace.text = scKeeper.GetNameOnPosition(3) + " " + scKeeper.GetScoreOnPosition(3);

        otherPlaces.text = scKeeper.GetNameOnPosition(4) + " " + scKeeper.GetScoreOnPosition(4) + Environment.NewLine +
            scKeeper.GetNameOnPosition(5) + " " + scKeeper.GetScoreOnPosition(5) + Environment.NewLine +
            scKeeper.GetNameOnPosition(6) + " " + scKeeper.GetScoreOnPosition(6) + Environment.NewLine +
            scKeeper.GetNameOnPosition(7) + " " + scKeeper.GetScoreOnPosition(7) + Environment.NewLine +
            scKeeper.GetNameOnPosition(8) + " " + scKeeper.GetScoreOnPosition(8) + Environment.NewLine +
            scKeeper.GetNameOnPosition(9) + " " + scKeeper.GetScoreOnPosition(9) + Environment.NewLine +
            scKeeper.GetNameOnPosition(10) + " " + scKeeper.GetScoreOnPosition(10) + Environment.NewLine;
    }
}
