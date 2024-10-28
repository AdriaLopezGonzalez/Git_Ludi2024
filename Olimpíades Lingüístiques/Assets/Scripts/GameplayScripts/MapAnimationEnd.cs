using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAnimationEnd : MonoBehaviour
{
    public void EndRace()
    {
        if(GameObject.FindAnyObjectByType<WordSelection>())
            GameObject.FindAnyObjectByType<WordSelection>().EndRace();
        else
            GameObject.FindAnyObjectByType<WordSelection_EasyMode>().EndRace();
    }
}
