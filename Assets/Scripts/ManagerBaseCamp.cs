using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ManagerBaseCamp : MonoBehaviour {

    public Text fundText;
    public TextMeshProUGUI weather;
    public __appManager app;

	// Use this for initialization
	void Start () {

        app = FindObjectOfType<__appManager>();

        fundText.text = "Funds: $" + app.getFunds();

        app.windSpeed = Random.Range(5, 11);
        app.temperature = Random.Range(25, 36);
        app.altitudeLevel = 0;
        
        weather.text = "Weather\n" + app.temperature + "\u00B0F | Wind " + app.windSpeed + " mph";

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
