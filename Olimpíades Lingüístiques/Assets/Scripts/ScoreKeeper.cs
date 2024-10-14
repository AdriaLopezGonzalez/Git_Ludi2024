using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    string[,] scoreList = new string[100, 2];

    // Start is called before the first frame update
    void Start()
    {

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
                scoreList[i, 0] = name;
                scoreList[i, 1] = score.ToString();

                RearrangeOrder();

                return;
            }

            else if (i == scoreList.Length - 1)
            {
                scoreList[i, 0] = name;
                scoreList[i, 1] = score.ToString();

                RearrangeOrder();
            }

        }
    }

    private void RearrangeOrder()
    {

    }

    private string GetScoreOnPosition(int position)
    {

        return "si";
    }
}
