using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerPermits : MonoBehaviour {

    public __appManager app;
    public Text fundsText;
    public Text partySizeText;
    public Button camp2;
    public Text camp2Text;
    public Button camp3;
    public Text camp3Text;
    public Button camp4;
    public Text camp4Text;
    public Button summit;
    public Text summitText;
    public Button sherpa1;
    public Text sherpa1Text;
    public Button sherpa2;
    public Text sherpa2Text;
    public Button sherpa3;
    public Text sherpa3Text;
    public Button sherpa4;
    public Text sherpa4Text;
    private int cost;

    // Use this for initialization
    void Start()
    {
        app = FindObjectOfType<__appManager>();
        updateText();


    }

    void Update()
    {
        Camp2Check();
        Camp3Check();
        Camp4Check();
        SummitCheck();
        Sherpa1Check();
        Sherpa2Check();
        Sherpa3Check();
        Sherpa4Check();
    }

    public void Sherpa1Check()
    {
        if (app.sherpaUpgrade1 && app.funds > 50000)
        {
            sherpa1.interactable = true;
            sherpa1Text.color = new Color(255, 255, 255, 1f);
        }
    }

    public void Sherpa2Check()
    {
        if (app.sherpaUpgrade2 && app.funds > 50000)
        {
            sherpa2.interactable = true;
            sherpa2Text.color = new Color(255, 255, 255, 1f);
        }
    }

    public void Sherpa3Check()
    {
        if (app.sherpaUpgrade3 && app.funds > 50000)
        {
            sherpa3.interactable = true;
            sherpa3Text.color = new Color(255, 255, 255, 1f);
        }
    }

    public void Sherpa4Check()
    {
        if (app.sherpaUpgrade4 && app.funds > 50000)
        {
            sherpa4.interactable = true;
            sherpa4Text.color = new Color(255, 255, 255, 1f);
        }
    }

    public void Camp2Check()
    {
        if (app.camp2Permit && app.funds > 50000)
        {
            camp2.interactable = true;
            camp2Text.color = new Color(255, 255, 255, 1f);
        }
    }

    public void Camp3Check()
    {
        if (app.camp3Permit && app.funds > 100000)
        {
            camp3.interactable = true;
            camp3Text.color = new Color(255, 255, 255, 1f);
        }
    }

    public void Camp4Check()
    {
        if (app.camp4Permit && app.funds > 125000)
        {
            camp4.interactable = true;
            camp4Text.color = new Color(255, 255, 255, 1f);
        }
    }

    public void SummitCheck()
    {
        if (app.summitPermit && app.funds > 150000)
        {
            summit.interactable = true;
            summitText.color = new Color(255, 255, 255, 1f);
        }
    }

    public void UnlockCamp2()
    {
        if (app.funds < 50000)
        {
            return;
        }
        else
        {
            app.funds = app.funds - 50000;
            app.camp2Permit = false;
            app.camp3Permit = true;
            app.camp2Unlocked = true;
            updateText();

            camp2.interactable = false;
            camp2Text.color = new Color(255, 255, 255, 0.5f);
        }
    }

    public void UnlockCamp3()
    {
        if (app.funds < 100000)
        {
            return;
        }
        else
        {
            app.funds = app.funds - 100000;
            app.camp3Permit = false;
            app.camp4Permit = true;
            app.camp3Unlocked = true;
            updateText();

            camp3.interactable = false;
            camp3Text.color = new Color(255, 255, 255, 0.5f);
        }
    }

    public void UnlockCamp4()
    {
        if (app.funds < 125000)
        {
            return;
        }
        else
        {
            app.funds = app.funds - 125000;
            app.camp4Permit = false;
            app.summitPermit = true;
            app.camp4Unlocked = true;
            updateText();

            camp4.interactable = false;
            camp4Text.color = new Color(255, 255, 255, 0.5f);
        }
    }

    public void UnlockSummit()
    {
        if (app.funds < 150000)
        {
            return;
        }
        else
        {
            app.funds = app.funds - 150000;
            app.summitUnlocked = true;
            app.summitPermit = false;
            updateText();

            summit.interactable = false;
            summitText.color = new Color(255, 255, 255, 0.5f);
        }
    }

    public void SherpaUpgrade1()
    {
        if (app.funds < 50000)
        {
            return;
        }
        else
        {
            app.funds = app.funds - 50000;
            app.maxPartySize = app.maxPartySize + 1;
            app.sherpaUpgrade1 = false;
            app.sherpaUpgrade2 = true;
            updateText();

            sherpa1.interactable = false;
            sherpa1Text.color = new Color(255, 255, 255, 0.5f);
        }
    }

    public void SherpaUpgrade2()
    {
        if (app.funds < 50000)
        {
            return;
        }
        else
        {
            app.funds = app.funds - 50000;
            app.maxPartySize = app.maxPartySize + 1;
            app.sherpaUpgrade2 = false;
            app.sherpaUpgrade3 = true;
            updateText();

            sherpa2.interactable = false;
            sherpa2Text.color = new Color(255, 255, 255, 0.5f);
        }
    }

    public void SherpaUpgrade3()
    {
        if (app.funds < 50000)
        {
            return;
        }
        else
        {
            app.funds = app.funds - 50000;
            app.maxPartySize = app.maxPartySize + 1;
            app.sherpaUpgrade3 = false;
            app.sherpaUpgrade4 = true;
            updateText();

            sherpa3.interactable = false;
            sherpa3Text.color = new Color(255, 255, 255, 0.5f);
        }
    }

    public void SherpaUpgrade4()
    {
        if (app.funds < 50000)
        {
            return;
        }
        else
        {
            app.funds = app.funds - 50000;
            app.maxPartySize = app.maxPartySize + 1;
            app.sherpaUpgrade4 = false;
            updateText();

            sherpa4.interactable = false;
            sherpa4Text.color = new Color(255, 255, 255, 0.5f);
        }
    }

    void updateText()
    {
        fundsText.text = "Funds: $" + app.getFunds();
        partySizeText.text = "Sherpas: " + app.getParty() + "/" + app.getMaxParty();
    }
}
