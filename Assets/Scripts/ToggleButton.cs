using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour {

    public __appManager app;
    public Button button;
    public Text text;
    public string check;

    // Use this for initialization
    void Start()
    {
        app = FindObjectOfType<__appManager>();

        if (app.isUnlocked(check) == false)
        {
            disableButton();
        }
    }

    public void disableButton()
    {
        button.interactable = false;
        text.color = new Color(255, 255, 255, 0.5f);

    }

    public void EnableButton()
    {
        button.interactable = true;
        text.color = Color.white;
    }

}
