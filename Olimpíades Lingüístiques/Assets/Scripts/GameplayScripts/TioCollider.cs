using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TioCollider : MonoBehaviour
{

    WordsStorage wStorage;
    WordsStorage_EasyMode wStorageEasy;

    private void Start()
    {
        if (GameObject.Find("Canvas").GetComponent<WordsStorage>())
            wStorage = GameObject.Find("Canvas").GetComponent<WordsStorage>();
        else
            wStorageEasy = GameObject.Find("Canvas").GetComponent<WordsStorage_EasyMode>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fence")
        {
            if (!ReferenceEquals(wStorage, null))
                wStorage.NextQuestion();
            else
                wStorageEasy.NextQuestion();
            other.enabled = false;
        }
    }
}
