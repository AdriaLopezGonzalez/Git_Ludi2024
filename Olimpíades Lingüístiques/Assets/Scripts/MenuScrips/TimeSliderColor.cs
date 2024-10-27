using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSliderColor : MonoBehaviour
{
    Image image;

    [SerializeField]
    Color startColor;

    [SerializeField]
    Color finalColor;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.color = Color.Lerp(finalColor, startColor, image.fillAmount);

    }
}
