using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SendScoreButton : MonoBehaviour
{
    [SerializeField] GameObject nameObject;
    [SerializeField] GameObject scoreCanvas;
    ScoreKeeper scoreKeeper;
    [SerializeField] GameObject endingPopUp;


    private void Start()
    {
        scoreKeeper = GameObject.FindAnyObjectByType<ScoreKeeper>();
    }

    public void SendToScoreKeeper()
    {
        string newName = nameObject.GetComponent<TextMeshProUGUI>().text.ToUpper();
        int newScore;
        if (scoreCanvas.GetComponent<WordSelection>())
            newScore = scoreCanvas.GetComponent<WordSelection>().GetPoints();
        else
            newScore = scoreCanvas.GetComponent<WordSelection_EasyMode>().GetPoints();

        scoreKeeper.EnterNewScore(newName, newScore);

        endingPopUp.SetActive(false);

        //TE ENVIA A LA ESCENA DEL MENU
    }


}
