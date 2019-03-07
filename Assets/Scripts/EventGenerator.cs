using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EventGenerator : MonoBehaviour {

    public __appManager app;

    public int destinationSceneNum;
    public Image scroll;
    public Image scroll2;
    public Image rScroll;
    public Image Climber;

    public bool paused = false;

    private ModalPanel modalPanel;

    public GameObject progressBar;

    private UnityAction okCheck;
    private UnityAction event1;
    private UnityAction turnAround;

    // Use this for initialization
    void Start () {

        app = FindObjectOfType<__appManager>();

        destinationSceneNum = app.nextCampScene;
	}


    void Awake()
    {
        modalPanel = ModalPanel.Instance();

        okCheck = new UnityAction(GoToCamp);
        event1 = new UnityAction(Event1);
        turnAround = new UnityAction(TurnAround);
    }


    public void ExpeditionEnd()
    {
        modalPanel.okCheck("You've made it to the next Camp!", okCheck);
    }

    public void GoToCamp()
    {
        LoadingScreenManager.LoadScene(destinationSceneNum); 
    }

    public void TurnAround()
    {
        LoadingScreenManager.LoadScene(app.lastSceneNum);
    }

    // Events that cause you to lost Rations/First Aid Kits
    public void Event1()
    {
        // Subtract supplies or something here.
        progressBar.GetComponent<ProgressBar>().UnPause();
        progressBar.GetComponent<ProgressBar>().startRNG();
    }

    private string GenerateRationEvent()
    {
        int roll = Random.Range(0, 6);

        if (roll == 1)
        {
            string[] eventPool1 = {"One of your climbers gear broke. Luckily your lead Sherpa brought an extra. \n\n -1 Climbing Gear",
                                   "A Carabiner broke during one of your Sherpa's ascent. Luckily no one was hurt. \n\n -1 Climbing Gear"};

            return eventPool1[Random.Range(0, eventPool1.Length)];
        }
        else if (roll == 2)
        {
            if (app.numBottles > 0)
            {
                app.numBottles = app.numBottles - 1;
            }

            return "One of the climbers was having trouble breathing. After a short break and some bottled oxygen, you decide to continue. \n\n -1 Oxygen Bottle(s)";
        }

        string[] eventPool = {"A Sherpa twists his ankle helping a climber over a big rock. After a short break while he gets patched up, you continue.\n\n -1 First Aid Kit(s)",
                              "One of your climbers starts hallucinating. You decide to take a short break before continuing.\n\n -1 Ration(s)",
                              "One of your climbers slips and falls, but a Sherpa caught them. After some rest, you continue on.\n\n -1 Ration(s)"};

        if (app.numRations > 0)
        {
            app.numRations = app.numRations - 1;
        }

        return eventPool[Random.Range(0, eventPool.Length)];
    }


    private string GenerateTurnArountEvent()
    {
        string[] eventPool = {"Satellite Reports that there is a high chance of Avelanche in this area. You decide it's too risky and head back to camp.",
                              "One of your climbers breaks their leg. You decide to go back to the last camp to call an airlift.",
                              "Increased snowfall and fog have severely reduced visibility. You decide to head back and wait it out." };

        return eventPool[Random.Range(0, eventPool.Length)];
    }

    public void RandomEvent()
    {
        modalPanel.okCheck(GenerateRationEvent(), event1);
    }

    public void RandomBigEvent()
    {
        modalPanel.okCheck(GenerateTurnArountEvent(), turnAround);
    }

    public void Complete()
    {
        scroll.GetComponent<ScrollReverse>().TogglePause();
        scroll2.GetComponent<Scroll>().TogglePause();
        rScroll.GetComponent<Scroll>().TogglePause();

        //Climber.GetComponent<Animator>().SetTrigger("Idle");

        modalPanel.okCheck("You've made it to the next Camp!\n\n -" + app.numClimbers / 4 + " Ration(s).", okCheck);
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            scroll.GetComponent<ScrollReverse>().TogglePause();
            scroll2.GetComponent<Scroll>().TogglePause();
            rScroll.GetComponent<Scroll>().TogglePause();

            //Climber.GetComponent<Animator>().SetTrigger("Idle");
            Climber.GetComponent<Animator>().SetTrigger("Fall");

            modalPanel.okCheck("OMFG YOU DIED!!!!!", okCheck);
        }

    }

}
