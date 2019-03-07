using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerRecruitment : MonoBehaviour {

    public __appManager app;
    public Text fundText;
    public Text partySizeText;

    // Use this for initialization
    void Start()
    {
        app = FindObjectOfType<__appManager>();
        fundText.text = "Funds: $" + app.getFunds();
        partySizeText.text = "Sherpas: " + app.getParty() + "/" + app.getMaxParty();
    }

    // Update is called once per frame
    void Update()
    {
        fundText.text = "Funds: $" + app.getFunds();
        partySizeText.text = "Sherpas: " + app.getParty() + "/" + app.getMaxParty();
    }
}
