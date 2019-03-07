using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerTeam : MonoBehaviour {

    public __appManager app;
    public Button button;

    // Use this for initialization
    void Start()
    {

        app = FindObjectOfType<__appManager>();

        if (app.activeContract)
        {
            //button.interactable = false;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
