using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecruitSherpa : MonoBehaviour {

    public __appManager app;
    public Button button;
    public Text Name, Cost, Age, FirstAid, Stamina, Survival;

    // Use this for initialization
    void Start () {

        app = FindObjectOfType<__appManager>();

        if (app.activeContract || app.partySize == app.maxPartySize)
        {
            button.interactable = false;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HireSherpa()
    {
        if (app.partySize >= app.maxPartySize)
        {
            return;
        }
        else
        {
            button.interactable = false;
            app.AddSherpa(Name.text, int.Parse(Age.text), int.Parse(FirstAid.text), int.Parse(Stamina.text), int.Parse(Survival.text));
            app.sherpaPower = app.sherpaPower + int.Parse(FirstAid.text) + int.Parse(Stamina.text) + int.Parse(Survival.text);
        }

    }

    public void FireSherpa()
    {
        if (app.partySize == 0)
        {
            return;
        }
        else
        {
            button.interactable = false;
            app.RemoveSherpa(Name.text);
            app.sherpaPower = app.sherpaPower - (int.Parse(FirstAid.text) + int.Parse(Stamina.text) + int.Parse(Survival.text));
        }

    }
}
