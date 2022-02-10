using System;
using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    #region Refs
    [Tooltip("The level to play.")]
    public Level Level = default;
    #endregion


    #region State
    /// <summary> Has the level been started? </summary>
    private bool _levelRunning = false;
    /// <summary> The amount of time left in the current level. </summary>
    private float _timeLeft;
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


    private void InitializeTimer()
    {
        throw new NotImplementedException();
    }

    #region Messages
    void Start()
    {
        _timeLeft = Level.Duration;
        InitializeTimer();
    }

    void Update()
    {
        if (_levelRunning)
        {
            var newTimeLeft = Mathf.Max(0, _timeLeft - Time.deltaTime);
            if (newTimeLeft != _timeLeft)
            {
                _timeLeft = newTimeLeft;
                UpdateTimer();
            }
            var newCookedAmount = Mathf.Min(100, _heatLevel * Time.deltaTime * Level.CookedMeterFillRate);
            if (newCookedAmount != _cookedAmount)
            {
                _cookedAmount = newCookedAmount;
                UpdateCookedView();
            }
            var newScrambleAmount = Mathf.Min(100, _shakeAmount * Time.deltaTime * Level.ScrambleMeterFillRate);
            if (newScrambleAmount != _scrambleAmount)
            {
                _scrambleAmount = newScrambleAmount;
                UpdateScrambleView();
            }
        }
    }

    #endregion


    #region View updates
    /// <summary> Emit event to update scramble meter to reflect <c>_scrambleAmount</c> </summary>
    private void UpdateScrambleView()
    {
        throw new NotImplementedException();
    }

    /// <summary> Emit event to update cooked meter to reflect <c>_cookedAmount</c> </summary>
    private void UpdateCookedView()
    {
        throw new NotImplementedException();
    }

    /// <summary> Emit event to update timer to reflect <c>_timeLeft</c> </summary>
    private void UpdateTimer()
    {
        throw new NotImplementedException();
    }
    #endregion
}
