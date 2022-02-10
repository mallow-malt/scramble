using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public delegate void TimerEnding();
    public static event TimerEnding TimerEnded;
    public float SecondsRemaining = 120;
    private bool _timerIsRunning = false;
    private Text _timerText;
    private void Start()
    {
        _timerText = gameObject.GetComponentInChildren<Text>();
        _timerIsRunning = true;
    }

    private void Update()
    {
        if (_timerIsRunning)
        {
            if (SecondsRemaining > 0)
                SecondsRemaining -= Time.deltaTime;
            else
            {
                SecondsRemaining = 0;
                _timerIsRunning = false;
                TimerEnded();
            }
            if(_timerText.text != TimeToString(SecondsRemaining))
                _timerText.text = TimeToString(SecondsRemaining);
        }
    }

    private string TimeToString(float timeRemaining)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60); 
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        return $"{minutes:00}:{seconds:00}";
    }
}