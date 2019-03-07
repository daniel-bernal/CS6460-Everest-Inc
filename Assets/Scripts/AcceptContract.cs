using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AcceptContract : MonoBehaviour {


    public __appManager app;
    public Button button;
    public Text Price, Destination, Climbers;
    public ModalPanel modalPanel;
    private UnityAction yesContract;
    private UnityAction noContract;
    private UnityAction okContract;

    void Awake()
    {
        modalPanel = ModalPanel.Instance();

        yesContract = new UnityAction(claimContract);
        noContract = new UnityAction(NoClaimContract);
        okContract = new UnityAction(NoClaimContract);
    }


    public void ContractCheck()
    {
        modalPanel.startCheck("Remember that your Sherpa Team is locked when you have an active Contract.\n\nAre you sure you want to accept this contract?", yesContract, noContract);
    }

    void NoClaimContract()
    {

    }

    // Use this for initialization
    void Start()
    {
        app = FindObjectOfType<__appManager>();

        UpdateButtons();
    }

    void UpdateButtons()
    {
        if (app.activeContract)
        {
            button.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateButtons();
    }

    public void claimContract()
    {
        if (app.activeContract)
        {
            return;
        }
        else
        {
            button.interactable = false;
            app.acceptContract(int.Parse(Price.text), int.Parse(Destination.text), int.Parse(Climbers.text));
            UpdateButtons();
        }

    }
}
