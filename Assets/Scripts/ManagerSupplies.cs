using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerSupplies : MonoBehaviour {

    public __appManager app;
    public Text fundsText;
    public Text expeditionSizeText;
    public Text rationText;
    public Text climbingText;
    public Text campingText;
    public Text bottleText;
    public Button rations;
    public Button climbing;
    public Button camping;
    public Button bottle;
    public Text rationBtnText;
    public Text climbingBtnText;
    public Text campingBtnText;
    public Text bottleBtnText;

    private int price = 500;

    // Use this for initialization
    void Start () {

        app = FindObjectOfType<__appManager>();
        updateText();
    }

    void updateText()
    {

        if (app.funds < price || app.getRations() >= (app.getMaxParty() * 2))
        {
            rations.interactable = false;
            rationBtnText.color = new Color(255, 255, 255, 0.5f);
        }
        if (app.funds < price || app.getClimbing() >= (app.getMaxParty() * 2))
        {
            climbing.interactable = false;
            climbingBtnText.color = new Color(255, 255, 255, 0.5f);
        }
        if (app.funds < price || app.getCamping() >= (app.getMaxParty() * 2))
        {
            camping.interactable = false;
            campingBtnText.color = new Color(255, 255, 255, 0.5f);
        }
        if (app.funds < price || app.getBottles() >= (app.getMaxParty() * 2))
        {
            bottle.interactable = false;
            bottleBtnText.color = new Color(255, 255, 255, 0.5f);
        }

        fundsText.text = "Funds: $" + app.getFunds();
        int total = app.getParty() + app.numClimbers;
        expeditionSizeText.text = "Climbers: " + total + "/" + (app.getMaxParty() * 2);

        rationText.text = "Owned: " + app.getRations() + "/" + (app.getMaxParty() * 2);
        climbingText.text = "Owned: " + app.getClimbing() + "/" + (app.getMaxParty() * 2); ;
        campingText.text = "Owned: " + app.getCamping() +  "/" + (app.getMaxParty() * 2); ;
        bottleText.text = "Owned: " + app.getBottles() +  "/" + (app.getMaxParty() * 2); ;
    }

    public void buyRation()
    {
        if (app.funds <= price || app.getRations() >= (app.getMaxParty() * 2))
        {
            return;

        }
        else
        {
            app.funds = app.funds - price;
            app.numRations = app.numRations + 1;
            updateText();
            return;
        }
    }

    public void buyClimbing()
    {
        if (app.funds <= price || app.getClimbing() >= (app.getMaxParty() * 2))
        {
            return;

        }
        else
        {
            app.funds = app.funds - price;
            app.numClimbing = app.numClimbing + 1;
            updateText();
            return;
        }
    }

    public void buyCamping()
    {
        if (app.funds <= price || app.getCamping() >= (app.getMaxParty() * 2))
        {
            return;

        }
        else
        {
            app.funds = app.funds - price;
            app.numCamping = app.numCamping + 1;
            updateText();
            return;
        }
    }

    public void buyBottle()
    {
        if (app.funds <= price || app.getBottles() >= (app.getMaxParty() * 2))
        {
            return;

        }
        else
        {
            app.funds = app.funds - price;
            app.numBottles = app.numBottles + 1;
            updateText();
            return;
        }
    }
}
