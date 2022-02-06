using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePan : MonoBehaviour
{
    [SerializeField] private Vector3 _position1 = default;
    [SerializeField] private Quaternion _angle1 = default;
    [SerializeField] private Vector3 _position2 = default;
    [SerializeField] private Quaternion _angle2 = default;

    private float _prog = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _prog += Time.deltaTime;
        var alpha = (Mathf.Sin(_prog) + 1) / 2;
        transform.localPosition = Vector3.Lerp(_position1, _position2, alpha);
        transform.rotation = Quaternion.Lerp(_angle1, _angle2, alpha);
    }
}
