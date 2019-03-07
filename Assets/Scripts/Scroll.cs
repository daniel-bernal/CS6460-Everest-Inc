using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{

    // Background scroll speed can be set in Inspector with slider
    [Range(1f, 20f)]
    public float scrollSpeed = 1f;
    public float defaultSpeed;
    public bool togglePause;

    // Scroll offset value to smoothly repeat backgrounds movement
    public float scrollOffset;

    // Start position of background movement
    Vector2 startPos;

    // Backgrounds new position
    float newPos;

    // Use this for initialization
    void Start()
    {
        // Getting backgrounds start position
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!togglePause)
        {
            // Calculating new backgrounds position repeating it depending on scrollOffset
            newPos = Mathf.Repeat(Time.time * -scrollSpeed, scrollOffset);

            // Setting new position
            transform.position = startPos + Vector2.right * newPos;
        }

    }

    public void TogglePause()
    {
        if (togglePause)
        {
            togglePause = false;
        }
        else
        {
            togglePause = true;
        }
    }

}
