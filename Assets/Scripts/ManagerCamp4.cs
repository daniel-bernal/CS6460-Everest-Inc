using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerCamp4 : MonoBehaviour
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

        if (app.summitUnlocked == false)
        {
            advance.interactable = false;
            advanceText.color = new Color(255, 255, 255, 0.5f);
        }

        if (app.destinationCamp == 4)
        {
            advance.interactable = false;
            advanceText.color = new Color(255, 255, 255, 0.5f);

            completeText.text = "Complete Expedition";
        }

        app.windSpeed = Random.Range(20, 31);
        app.temperature = Random.Range(-25, -17);
        app.altitudeLevel = 4;

        weather.text = "Weather\n" + app.temperature + "\u00B0F | Wind " + app.windSpeed + " mph";

    }

    // Update is called once per frame
    void Update()
    {

    }
}
