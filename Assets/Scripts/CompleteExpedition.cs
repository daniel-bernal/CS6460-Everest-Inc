using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompleteExpedition : MonoBehaviour {

    public __appManager app;
    public Button button;
    public TextMeshProUGUI buttonText;

    // Use this for initialization
    void Start () {
        app = FindObjectOfType<__appManager>();
    }

    public void ExpeditionComplete()
    {

        if (buttonText.text == "Complete Expedition")
        {
            app.completeContract();
            LoadingScreenManager.LoadScene(1);
        }
    }
}
