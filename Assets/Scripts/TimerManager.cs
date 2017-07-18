/*
 * Add a way to reset the timer when you get to a new stage
 * Make ennemies spawn in the stage when the timer reaches 0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

    private float timeLeft = 90.0f;
    public bool stop = true;

    private float minutes;
    private float seconds;

    [SerializeField] Text timerText;

    public void startTimer(float from)
    {
        stop = false;
        timeLeft = from;
        Update();
        StartCoroutine(updateCoroutine());
    }
    
    // Use this for initialization
	void Start ()
    {
        startTimer(90.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (stop)
        {
            return;
        }

        timeLeft -= Time.deltaTime;

        minutes = Mathf.Floor(timeLeft / 60);
        seconds = timeLeft % 60;
        if(seconds > 59)
        {
            seconds = 59;
        }
        if(minutes < 0)
        {
            stop = true;
            minutes = 0;
            seconds = 0;
        }
	}

    private IEnumerator updateCoroutine()
    {
        while(!stop)
        {
            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            yield return new WaitForSeconds(0.2f);
        }
    }

    void RestartTimer()
    {
        timeLeft = 90.0f;
    }
}
