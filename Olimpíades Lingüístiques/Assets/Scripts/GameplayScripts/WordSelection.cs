using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSelection : MonoBehaviour
{
    [SerializeField]
    Slider timeSlider;
    [SerializeField]
    float timeSubtract;
    [SerializeField]
    float timeIncrease;

    WordsStorage wordsStorageScript;

    void Start()
    {
        wordsStorageScript = GetComponent<WordsStorage>();
    }

    void Update()
    {
        
    }

    public void WordSelected(int buttonPressed)
    {
        if (wordsStorageScript.GetCorrectButton() == buttonPressed)
        {
            Debug.Log("tt acertao");
            //sube tiempo, puntos y animacion ganas con evento que lleva a cambiar palabras
            // si has superado x puntos o x palabras acertadas, pasar a dificiles
        }
        else
        {
            Debug.Log("has perdio");
            // animacion pierdes con evento que lleva a cambiar palabras
        }
        //TIEMPO NO BAJA CUANDO ESTA EN CURSO ANIMACION!!!!!!!!

    }
}
