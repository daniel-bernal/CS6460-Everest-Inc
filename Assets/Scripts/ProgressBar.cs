using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    public __appManager app;
    public Image progress;
    public Text textMesh;
    public GameObject journey;

    private bool paused = false;

    private float endTime;

    private int climbTime = 20;

    private int rng;
    private int timeLeft;

    // Use this for initialization
    void Start () {

        app = FindObjectOfType<__appManager>();

        endTime = Time.time + climbTime;
        textMesh.text = climbTime.ToString();

        // random event generator waits 1 second, and RNG every 3 seconds
        startRNG();
    }


    public void startRNG()
    {
        InvokeRepeating("RandomEvent", 1.0f, 3.0f);
    }
    public void UnPause()
    {
        paused = false;
        endTime = Time.time + (timeLeft);
    }

    public void RandomEvent()
    {
        rng = Random.Range(1, 150);
        //Debug.LogWarning("RNG IS: " + rng);

        if (rng >= 80 + app.sherpaPower && rng < 140)
        {
            journey.GetComponent<EventGenerator>().RandomEvent();
            CancelInvoke(); // cancel the random even generator
            paused = true;
        }
        else if(rng >= 145)
        {
            journey.GetComponent<EventGenerator>().RandomBigEvent();
            CancelInvoke(); // cancel the random even generator
            paused = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            timeLeft = (int)endTime - (int)Time.time;

            progress.fillAmount = ((float)timeLeft / (float)climbTime);

            if (timeLeft < 0)
            {
                CancelInvoke(); // cancel the random even generator
                timeLeft = 0;
                journey.GetComponent<EventGenerator>().Complete();
            }
            else
            {
                textMesh.text = timeLeft.ToString();
            }
        }
    }
}
