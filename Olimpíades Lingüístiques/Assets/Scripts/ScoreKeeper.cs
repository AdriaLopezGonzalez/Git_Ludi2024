using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    string[,] scoreList = new string[100, 2];

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD

=======
        EnterNewScore("GTS", 50);
        //EnterNewScore("TET", 550);
        //EnterNewScore("PTO", 100);

        Debug.Log(scoreList[0].playerName + " " + scoreList[0].playerScore);
        Debug.Log(scoreList[1].playerName + " " + scoreList[0].playerScore);
        Debug.Log(scoreList[2].playerName + " " + scoreList[0].playerScore);
>>>>>>> parent of 8440d14 (scorekeeper finished)
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterNewScore(string name, float score)
    {
        for (int i = 0; i < scoreList.Length; i++)
        {
            if (scoreList[i, 0] != null)
            {
<<<<<<< HEAD
                scoreList[i, 0] = name;
                scoreList[i, 1] = score.ToString();
=======
                scoreList[i] = new Score(name, score);

>>>>>>> parent of 8440d14 (scorekeeper finished)

                RearrangeOrder();

                return;
            }

            else if (i == scoreList.Length - 1)
            {
<<<<<<< HEAD
                scoreList[i, 0] = name;
                scoreList[i, 1] = score.ToString();

=======
                scoreList[i] = new Score(name, score);



>>>>>>> parent of 8440d14 (scorekeeper finished)
                RearrangeOrder();
            }

        }
    }

    private void RearrangeOrder()
    {
<<<<<<< HEAD

    }
=======
        //Array.Sort(scoreList[].playerScore);
        int[] scoreArray = new int[scoreList.Length];

        for (int i = 0; i < scoreList.Length; i++)
        {
            if (ReferenceEquals(scoreList[i], null))
            {
                //scoreArray[i] = -1;
            }
            else
            {
                scoreArray[i] = scoreList[i].playerScore;
                Debug.Log(scoreList[i].playerName + " hemos entrao "+ scoreArray[i]);
            }
        }

        Array.Sort(scoreArray);

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
>>>>>>> parent of 8440d14 (scorekeeper finished)

    private string GetScoreOnPosition(int position)
    {

        return "si";
    }
}
