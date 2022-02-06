using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Grab : MonoBehaviour
{
    [SerializeField] private GameObject _openModel = null;
    [SerializeField] private GameObject _closedModel = null;

    public bool Closed = false;

    void Update()
    {
        _openModel.SetActive(!Closed);
        _closedModel.SetActive(Closed);
    }
}
