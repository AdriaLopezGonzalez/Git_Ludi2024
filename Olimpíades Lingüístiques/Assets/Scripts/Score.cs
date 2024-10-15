using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Score(string name, int score)
    {
        playerName = name;
        playerScore = score;
    }

    public string playerName;
    public int playerScore;

}
