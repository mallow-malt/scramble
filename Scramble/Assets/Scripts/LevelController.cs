using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    #region Refs
    [Tooltip("The level to play.")]
    public Level Level = default;
    [SerializeField] private Timer _timer;
    public UnityEvent<float> OnCookedChange;
    public UnityEvent<float> OnScrambledChange;
    #endregion


    #region State
    /// <summary> Has the level been started? </summary>
    private bool _levelRunning = false;
    /// <summary> The amount cooked the eggs are, from 0 to 100. </summary>
    private float _cookedAmount;
    /// <summary> The ammount scrambled the eggs are, from 0 to 100. </summary>
    private float _scrambleAmount;
    #endregion

    /// <summary> How hot is the pan? </summary>
    public float _heatLevel
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    /// <summary> How aggressively was the pan shaken? </summary>
    public float _shakeAmount
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    /// <summary> Start the level. Shows the level start message and starts counting down. </summary>
    public void StartLevel()
    {
        _levelRunning = true;
        var levelDiff = 1f / (Level.Recipe.Count + 1);
        for (int i = 0; i < Level.Recipe.Count; ++i)
        {
            var ingredient = Level.Recipe[i].Ingredient;
            var _ = StartCoroutine(SlideInIngredient(i * levelDiff, ingredient));
        }
    }

    #region Coroutines
    /// <summary> Coroutine to slide an ingredient in from the side. </summary>
    /// <param name="depth"> Where should the ingredient slide in from? Nearest the counter edge is 0, nearest the wall is 1.  </param>
    /// <param name="ingredient"> The ingredient to slide in. </param>
    IEnumerator SlideInIngredient(float depth, Ingredient ingredient)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Messages
    void Start()
    {
        _timer.OnTimerEnded.AddListener(OnTimerEnded);
        _timer.InitTimer(Level.Duration);
    }

    private void OnTimerEnded()
    {
        throw new NotImplementedException();
    }

    void Update()
    {
        if (_levelRunning)
        {
            var newCookedAmount = Mathf.Min(100, _heatLevel * Time.deltaTime * Level.CookedMeterFillRate);
            if (newCookedAmount != _cookedAmount)
            {
                _cookedAmount = newCookedAmount;
                OnCookedChange.Invoke(_cookedAmount);
            }
            var newScrambleAmount = Mathf.Min(100, _shakeAmount * Time.deltaTime * Level.ScrambleMeterFillRate);
            if (newScrambleAmount != _scrambleAmount)
            {
                _scrambleAmount = newScrambleAmount;
                OnScrambledChange.Invoke(_scrambleAmount);
            }
        }
    }

    #endregion
}
