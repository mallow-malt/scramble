using UnityEngine;

[CreateAssetMenu(menuName = "Scramble/Ingredient")]
public class Ingredient : ScriptableObject
{
    [Tooltip("The name that will be displayed when refereing to the ingredient.")]
    public string Name = "UNNAMED";
    [Tooltip("The prefab that represents this ingredient in a container.")]
    public GameObject InContainer = default;
    [Tooltip("The prefab that represents an individual piece of this ingredient.")]
    public GameObject Individual = default;
}
