using UnityEngine;
using System.Linq;

public class FireRandomizer : MonoBehaviour
{
    [SerializeField] private GameObject[] _burners;
    [SerializeField] private float _burnerTime = 5f;
    private int _activeBurner;

    private void Start()
    {
        InvokeRepeating("ChangeBurner", 0, _burnerTime);
    }

    private void ChangeBurner()
    {
        int newBurner;
        do
        {
            newBurner = Random.Range(0, _burners.Length);
        } while (newBurner == _activeBurner);
        _activeBurner = newBurner;
    }

    private void Update()
    {
        foreach ((GameObject burner, int index) in _burners.Select((value, i) => (value, i)))
        {
            Fire burnerState = burner.GetComponent<Fire>();
            burnerState.Active = index == _activeBurner;
        }
    }
}
