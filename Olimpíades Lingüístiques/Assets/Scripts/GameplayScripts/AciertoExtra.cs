using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AciertoExtra : MonoBehaviour
{
    Slider slider;

    public float timeIncrease;
    public int greatMultiplierMin;
    public int greatMultiplierMax;
    public int normalMultiplierMin;
    public int normalMultiplierMax;

    public int greatMultiplierMult;
    public int normalMultiplierMult;

    bool ongoing = false;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //darle al tiempo y llega al max value acabar sin na
        if(ongoing)
            slider.value = timeIncrease * Time.deltaTime;

        if (slider.value >= slider.maxValue)
            GoBack();


    }

    public void AciertoAchieved()
    {
        ongoing = true;
    }

    public void OnClick()
    {
        if(slider.value >greatMultiplierMin && slider.value < greatMultiplierMax)
        {
            //sumar multipliers
            GoBack();
        }
        else if (slider.value > normalMultiplierMin && slider.value < normalMultiplierMax)
        {
            //sumar multipliers
            GoBack();
        }
        else
        {
            GoBack();
        }

    }

    private void GoBack()
    {
        // volver a words selection con o sin puntos
    }

}
