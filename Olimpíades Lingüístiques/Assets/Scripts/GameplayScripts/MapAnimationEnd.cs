using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAnimationEnd : MonoBehaviour
{
    public void EndRace()
    {
        GameObject.FindAnyObjectByType<WordSelection>().EndRace();
    }
}
