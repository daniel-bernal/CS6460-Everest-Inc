using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerCamp2 : MonoBehaviour
{

    public Text fundText;
    public __appManager app;
    public Button advance;
    public Text advanceText;
    public TextMeshProUGUI completeText;
    public TextMeshProUGUI weather;

    // Use this for initialization
    void Start()
    {

        app = FindObjectOfType<__appManager>();

        fundText.text = "Funds: $" + app.getFunds();

        if (app.camp3Unlocked == false)
        {
            advance.interactable = false;
            advanceText.color = new Color(255, 255, 255, 0.5f);
        }

        if (app.destinationCamp == 2)
        {
            advance.interactable = false;
            advanceText.color = new Color(255, 255, 255, 0.5f);

            completeText.text = "Complete Expedition";
        }

        app.windSpeed = Random.Range(12, 21);
        app.temperature = Random.Range(-2, 4);
        app.altitudeLevel = 2;

        weather.text = "Weather\n" + app.temperature + "\u00B0F | Wind " + app.windSpeed + " mph";

    }

    // Update is called once per frame
    void Update()
    {

    }
}
