using UnityEngine;
using TMPro;
using System;

public class MenuScoreSetter : MonoBehaviour
{
    ScoreKeeper scKeeper;

    [Header("names")]
    [SerializeField] TMP_Text firstPlaceN;
    [SerializeField] TMP_Text secondPlaceN;
    [SerializeField] TMP_Text thirdPlaceN;
    [SerializeField] TMP_Text fourthPlaceN;
    [SerializeField] TMP_Text fifthPlaceN;

    [Header("points")]
    [SerializeField] TMP_Text firstPlaceP;
    [SerializeField] TMP_Text secondPlaceP;
    [SerializeField] TMP_Text thirdPlaceP;
    [SerializeField] TMP_Text fourthPlaceP;
    [SerializeField] TMP_Text fifthPlaceP;

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

        firstPlaceN.text = scKeeper.GetNameOnPosition(1) ;
        secondPlaceN.text = scKeeper.GetNameOnPosition(2);
        thirdPlaceN.text = scKeeper.GetNameOnPosition(3) ;
        fourthPlaceN.text = scKeeper.GetNameOnPosition(4);
        fifthPlaceN.text = scKeeper.GetNameOnPosition(5);

        firstPlaceP.text = scKeeper.GetScoreOnPosition(1);
        secondPlaceP.text = scKeeper.GetScoreOnPosition(2);
        thirdPlaceP.text = scKeeper.GetScoreOnPosition(3);
        fourthPlaceP.text = scKeeper.GetScoreOnPosition(4);
        fifthPlaceP.text = scKeeper.GetScoreOnPosition(5);

        /*otherPlaces.text = scKeeper.GetNameOnPosition(4) + " " + scKeeper.GetScoreOnPosition(4) + Environment.NewLine +
            scKeeper.GetNameOnPosition(5) + " " + scKeeper.GetScoreOnPosition(5) + Environment.NewLine +
            scKeeper.GetNameOnPosition(6) + " " + scKeeper.GetScoreOnPosition(6) + Environment.NewLine +
            scKeeper.GetNameOnPosition(7) + " " + scKeeper.GetScoreOnPosition(7) + Environment.NewLine +
            scKeeper.GetNameOnPosition(8) + " " + scKeeper.GetScoreOnPosition(8) + Environment.NewLine +
            scKeeper.GetNameOnPosition(9) + " " + scKeeper.GetScoreOnPosition(9) + Environment.NewLine +
            scKeeper.GetNameOnPosition(10) + " " + scKeeper.GetScoreOnPosition(10) + Environment.NewLine;*/
    }
}
