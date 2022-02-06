using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Timer : MonoBehaviour
{
    public delegate void UpdateTimerString(string NewTime);
    public static event UpdateTimerString UpdateTimer;
    public float TimeRemaining = 120;
    private bool TimerIsRunning = false;
    private void Start()
    {
        TimerIsRunning = true;
    }

    private void Update()
    {
        if (TimerIsRunning)
        {
            if (TimeRemaining > 0)
            {
                TimeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                TimeRemaining = 0;
                TimerIsRunning = false;
            }
            UpdateTimer(TimeToString(TimeRemaining));
        }
    }

    private string TimeToString(float timeRemaining)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60); 
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        return $"{minutes:00}:{seconds:00}";
    }
}