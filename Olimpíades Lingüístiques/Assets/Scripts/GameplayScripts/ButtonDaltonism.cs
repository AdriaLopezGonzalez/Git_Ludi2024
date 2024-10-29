using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDaltonism : MonoBehaviour
{
    [SerializeField] bool isGood;

    Color greenColor = new Color(0, 1, 0.04455471f, 1);
    Color blueColor = new Color(0.2666667f, 0.957945f, 1, 1);

    Color redColor = new Color(1, 0, 0, 1);
    Color orangeColor = new Color(0.8553459f, 0.4507591f, 0, 1);

    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        if (GameController.GetGameController().daltonismIsActive)
        {
            if (isGood)
                image.color = blueColor;
            else
                image.color = orangeColor;
        }
        else
        {
            if (isGood)
                image.color = greenColor;
            else
                image.color = redColor;
        }
    }

}
