using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInPalm : MonoBehaviour
{
    [SerializeField] private Collider _handleCollider = null;

    [SerializeField]
    public bool Colliding { get; private set; } = false;

    void OnTriggerEnter(Collider other)
    {
        if (other == _handleCollider)
        {
            Colliding = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other == _handleCollider)
        {
            Colliding = false;
        }
    }
}
