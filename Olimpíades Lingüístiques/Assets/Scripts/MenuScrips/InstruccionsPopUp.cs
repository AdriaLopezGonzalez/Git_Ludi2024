using UnityEngine;
using UnityEngine.UI;

public class InstruccionsPopUp : MonoBehaviour
{
    bool started = false;

    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;

    void Start()
    {
        if (!started)
        {

            button1.interactable = false;
            button2.interactable = false;
            button3.interactable = false;
        }
        else
            gameObject.SetActive(false);
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
        started = true;
        gameObject.SetActive(false);
    }
}
