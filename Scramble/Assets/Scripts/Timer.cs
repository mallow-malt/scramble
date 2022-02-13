using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent OnTimerEnded;
    private float _secondsRemaining = 120;
    private bool _timerIsRunning = false;
    private Text _timerText;
    private void Start()
    {
        _timerText = gameObject.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (_timerIsRunning)
        {
            if (_secondsRemaining > 0)
                _secondsRemaining -= Time.deltaTime;
            else
            {
                _secondsRemaining = 0;
                _timerIsRunning = false;
                OnTimerEnded.Invoke();
            }
        }
        if(_timerText.text != TimeToString(_secondsRemaining))
            _timerText.text = TimeToString(_secondsRemaining);
    }

    private string TimeToString(float timeRemaining)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60); 
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        return $"{minutes:00}:{seconds:00}";
    }

    public void StartTimer()
    {
        _timerIsRunning = true;
    }

    public void StopTimer()
    {
        _timerIsRunning = false;
    }

    public void InitTimer(float seconds)
    {
        _timerIsRunning = false;
        _secondsRemaining = seconds;
    }
}
