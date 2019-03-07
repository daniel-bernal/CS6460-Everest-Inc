using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class __appManager : MonoBehaviour {

    public int funds;
    public int daysGone;
    public bool camp2Unlocked;
    public bool camp3Unlocked;
    public bool camp4Unlocked;
    public bool summitUnlocked;
    public bool camp2Permit;
    public bool camp3Permit;
    public bool camp4Permit;
    public bool summitPermit;
    public bool sherpaUpgrade1;
    public bool sherpaUpgrade2;
    public bool sherpaUpgrade3;
    public bool sherpaUpgrade4;

    public int partySize;
    public int maxPartySize;

    private int contractLevel;
    private int contractRisk;
    public int destinationCamp;
    public int numClimbers;
    public bool activeContract;
    private int contractPrice;

    public int numRations;
    public int numClimbing;
    public int numCamping;
    public int numBottles;

    public int windSpeed;
    public int temperature;
    public int altitudeLevel;

    private int count;

    public int lastSceneNum;

    public int sherpaPower;

    // track next camp scene
    public int nextCampScene;

    public List<Sherpa> sherpaTeam;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    public void Start () {

        funds = 450000;
        daysGone = 0;

        camp2Unlocked = false;
        camp3Unlocked = false;
        camp4Unlocked = false;
        summitUnlocked = false;
        camp2Permit = true;
        camp3Permit = false;
        camp4Permit = false;
        summitPermit = false;
        sherpaUpgrade1 = true;
        sherpaUpgrade2 = false;
        sherpaUpgrade3 = false;
        sherpaUpgrade4 = false;

        // number of sherpas and max number of sherpas
        partySize = 0;
        maxPartySize = 4;

        // contract details
        contractLevel = 0;
        contractRisk = 0;
        destinationCamp = 0;
        numClimbers = 0;
        activeContract = false;
        contractPrice = 0;

        
        // items from item shop
        numRations = 4;
        numClimbing = 4;
        numCamping = 4;
        numBottles = 4;

        // weather conditions
        windSpeed = 0;
        temperature = 0;
        altitudeLevel = 0;

        count = 0;

        sherpaTeam = new List<Sherpa>();

        Sherpa newSherpa = new Sherpa("Sherpa Daniel", 29, 3, 3, 3);

        sherpaTeam.Add(newSherpa);
        partySize++;
        sherpaPower = 9;
        

    }

    public class Sherpa
    {
        public string name;
        public int firstAid, stamina, survival, age, id;

        public __appManager app;

        public Sherpa(string sName, int sAge, int sFirstAid, int sStamina, int sSurvival)
        {
            app = FindObjectOfType<__appManager>();

            name = sName;
            age = sAge;
            firstAid = sFirstAid;
            stamina = sStamina;
            survival = sSurvival;

            id = app.getSherpaCount();
        }
    }


    public int getSherpaCount()
    {
        count++;
        return count;
    }

    public int getRations()
    {
        return numRations;
    }

    public int getClimbing()
    {
        return numClimbing;
    }

    public int getCamping()
    {
        return numCamping;
    }

    public int getBottles()
    {
        return numBottles;
    }

    public int getFunds()
    {
        return funds;
    }

    public int getParty()
    {
        return partySize;
    }

    public int getMaxParty()
    {
        return maxPartySize;
    }

    public bool isUnlocked(string variableName)
    {
        if (variableName == "camp2Permit")
        {
            return camp2Permit;
        }
        else if (variableName == "camp3Permit")
        {
            return camp3Permit;
        }
        else if (variableName == "camp4Permit")
        {
            return camp4Permit;
        }
        else if (variableName == "summitPermit")
        {
            return summitPermit;
        }
        else if (variableName == "sherpaUpgrade1")
        {
            return sherpaUpgrade1;
        }
        else if (variableName == "sherpaUpgrade2")
        {
            return sherpaUpgrade2;
        }
        else if (variableName == "sherpaUpgrade3")
        {
            return sherpaUpgrade3;
        }
        else if (variableName == "sherpaUpgrade4")
        {
            return sherpaUpgrade4;
        }
        else { return false; }
    }

    public void AddSherpa(string name, int age, int firstAid, int stamina, int survival)
    {

        if (sherpaTeam.Count >= getMaxParty())
        {
            return;
        }
        Sherpa newSherpa = new Sherpa(name, age, firstAid, stamina, survival);

        sherpaTeam.Add(newSherpa);
        partySize++;

        Debug.LogWarning("Sherpa Added. There are " + sherpaTeam.Count + " Total Sherpas.");
    }

    public void RemoveSherpa(string name)
    {

        if (sherpaTeam.Count == 0)
        {
            return;
        }

        Sherpa removeSherpa = sherpaTeam.Find(x => x.name == name);
        sherpaTeam.Remove(removeSherpa);
        partySize--;

        Debug.LogWarning("Sherpa Removed. There are " + sherpaTeam.Count + " Total Sherpas.");
    }

    public void acceptContract(int price, int destination, int climbers)
    {
        if (activeContract)
        {
            return;
        }

        contractLevel = destination;
        destinationCamp = destination;
        contractPrice = price;
        numClimbers = climbers;
        activeContract = true;

        Debug.LogWarning("Contract Accepted...");
    }

    public void completeContract()
    {
        int sherpaCost, cost = 0;

        foreach (Sherpa sherpa in sherpaTeam)
        {
            if (sherpa.firstAid + sherpa.stamina + sherpa.survival == 15)
            {
                sherpaCost = 10000;
            }
            else if (sherpa.firstAid + sherpa.stamina + sherpa.survival >= 12)
            {
                sherpaCost = 7500;
            }
            else if (sherpa.firstAid + sherpa.stamina + sherpa.survival >= 9)
            {
                sherpaCost = 5000;
            }
            else if (sherpa.firstAid + sherpa.stamina + sherpa.survival >= 6)
            {
                sherpaCost = 2500;
            }
            else
            {
                sherpaCost = 1000;
            }

            cost += sherpaCost;
        }

        funds = funds + contractPrice - cost;

        contractLevel = 0;
        destinationCamp = 0;
        contractPrice = 0;
        numClimbers = 0;
        activeContract = false;

        Debug.LogWarning("Contract completed...");
    }

}
