using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scramble/Level")]
public class Level : ScriptableObject
{
    [Serializable]
    public class RecipeEntry
    {
        [Tooltip("The ingredient this entry require.")]
        public Ingredient Ingredient = default;
        [Tooltip("The number of pieces of the ingredient required.")]
        public int Pieces = 1;
    }

    [Tooltip("The amount of time from the level to start to the level timeout (in seconds).")]
    public int Duration = 60;
    [Tooltip("The ingredients and amounts this level requires.")]
    public List<RecipeEntry> Recipe = new List<RecipeEntry>();
    [Tooltip("How long a burner stays lit before changing (in seconds).")]
    public float BurnerStayDuration = 5;
    [Tooltip("How quickly does the cooked meter fill. 2 = twices as fast.")]
    public float CookedMeterFillRate = 1;
    [Tooltip("How quickly does the scramble meter fill. 2 = twices as fast.")]
    public float ScrambleMeterFillRate = 1;
}
