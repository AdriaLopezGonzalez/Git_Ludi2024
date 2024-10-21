using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TioCollider : MonoBehaviour
{

    WordsStorage wStorage;

    private void Start()
    {
        wStorage = GameObject.Find("Canvas").GetComponent<WordsStorage>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fence")
        {
            wStorage.NextQuestion();
        }
    }
}
