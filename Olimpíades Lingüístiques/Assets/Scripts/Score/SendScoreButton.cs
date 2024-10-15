using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SendScoreButton : MonoBehaviour
{
    [SerializeField] GameObject nameObject;
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject scoreKeeper;
    [SerializeField] GameObject endingPopUp;

    public void SendToScoreKeeper()
    {
        string newName = nameObject.GetComponent<TextMeshProUGUI>().text;
        int newScore = scoreCanvas.GetComponent<WordSelection>().GetPoints();
        scoreKeeper.GetComponent<ScoreKeeper>().EnterNewScore(newName, newScore);

        endingPopUp.SetActive(false);

        //TE ENVIA A LA ESCENA DEL MENU
    }


}
