using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController = null;

    public static bool alreadyInitializated = false;

    public ScoreKeeper scoreKeeper;

    public bool daltonismIsActive;

    public bool reducedVisibilityIsActive;

    public float musicVolume;
    public float VoicesVolume;

    public static GameController GetGameController()
    {
        if (gameController == null && !alreadyInitializated)
        {
            GameObject gameObject = new GameObject("GameController");
            gameController = gameObject.AddComponent<GameController>();
            GameController.DontDestroyOnLoad(gameObject);
            alreadyInitializated = true;
        }
        return gameController;
    }
}
