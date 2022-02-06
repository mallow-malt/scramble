using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public bool Active = false;
    //Temporary until we update graphics
    public Material noFire;
    public Material onFire;

    
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if(Active)
            _renderer.material = onFire;
        else
            _renderer.material = noFire;
    }
}
