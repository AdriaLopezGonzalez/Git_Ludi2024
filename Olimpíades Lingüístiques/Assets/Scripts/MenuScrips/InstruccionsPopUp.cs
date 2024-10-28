using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstruccionsPopUp : MonoBehaviour
{
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;

    void Start()
    {
        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnClick();
    }

    private void OnClick()
    {
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;
        gameObject.SetActive(false);
    }
}
