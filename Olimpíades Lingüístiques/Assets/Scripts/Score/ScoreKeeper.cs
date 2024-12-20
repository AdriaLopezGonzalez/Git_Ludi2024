using System;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    Score[] scoreList = new Score[10];

    private void Awake()
    {
        if (GameController.GetGameController().scoreKeeper == null)
        {
            GameController.GetGameController().scoreKeeper = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
        EnterNewScore("ESN", 500);
        EnterNewScore("JCI", 100);
        EnterNewScore("AFT", 1250);
    }

    void Start()
    {
        /*
        EnterNewScore("FIT", 120);
        EnterNewScore("SOK", 90);
        EnterNewScore("KIK", 300);
        EnterNewScore("ALG", 549);
        EnterNewScore("JJM", 600);
        EnterNewScore("PFB", 9000);
        EnterNewScore("POP", 5);
        EnterNewScore("GTS", 10);

        for (int i = 0; i < scoreList.Length; i++)
        {
            Debug.Log(i+1 + " = " + scoreList[i].playerName + " " + scoreList[i].playerScore);
        }
        */
    }

    void Update()
    {

    }

    public void EnterNewScore(string name, int score)
    {
        for (int i = 0; i < scoreList.Length; i++)
        {

            if (ReferenceEquals(scoreList[i], null))
            {
                scoreList[i] = new Score(name, score);
                //Debug.Log("round: "+ i + ", name: "+scoreList[i].playerName+ " is " + ReferenceEquals(scoreList[i], null));


                RearrangeOrder();

                return;
            }

            else if (i == scoreList.Length - 1)
            {
                if (score > scoreList[i].playerScore)
                {
                    scoreList[i] = new Score(name, score);

                    RearrangeOrder();
                }
            }

        }

    }

    private void RearrangeOrder()
    {

        int[] scoreArray = new int[scoreList.Length];

        for (int i = 0; i < scoreList.Length; i++)
        {
            if ((!ReferenceEquals(scoreList[i], null)) && (scoreArray[i] == 0))
            {
                scoreArray[i] = scoreList[i].playerScore;
                //Debug.Log("ronda" + i + " jugador:" + scoreList[i].playerName + " hemos entrao "+ scoreArray[i]);
            }
        }

        Array.Sort(scoreArray);
        Array.Reverse(scoreArray);

        string[] nameArray = new string[scoreList.Length];

        for (int i = 0; i < scoreArray.Length; i++)
        {
            for (int j = 0; j < scoreList.Length; j++)
            {
                if (!ReferenceEquals(scoreList[j], null))
                {
                    if (scoreArray[i] == scoreList[j].playerScore)
                    {
                        nameArray[i] = scoreList[j].playerName;
                    }
                }
            }
        }

        for (int i = 0; i < scoreArray.Length; i++)
        {
            if (!ReferenceEquals(scoreList[i], null))
            {
                scoreList[i] = new Score(nameArray[i], scoreArray[i]);
            }
        }

        //fer una array buida i omplirla de tots els numeros
        //ordenar aquella array
        //fer una altra array de strings amb el mateix ordre i assignar noms
        //assignar a la array scoreList el ordre correcte

    }

    public string GetScoreOnPosition(int position)
    {
        if (!ReferenceEquals(scoreList[position-1], null))
            return scoreList[position-1].playerScore.ToString();
        else
            return string.Empty;
    }

    public string GetNameOnPosition(int position)
    {
        if (!ReferenceEquals(scoreList[position-1], null))
            return scoreList[position-1].playerName;
        else
            return string.Empty;
    }
}
