using UnityEngine;
using UnityEngine.Events;

public class FireChecker : MonoBehaviour
{
    public UnityEvent<float> OnCookedChange;
    [SerializeField] private bool _drawGizmo = false;

    // Higher numbers = smaller colliders
    [SerializeField] private float _scale = 1f;
    private LayerMask _layerMask;
    private float _cookedPercent;

    private void Start()
    {
        _layerMask = LayerMask.GetMask("Fire");
    }

    private void FixedUpdate()
    {
        Collider[] HitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale * (_scale / 2), Quaternion.identity, _layerMask);
        foreach (var Collider in HitColliders)
        {
            Fire burnerState = Collider.GetComponent<Fire>();
            if(burnerState.Active)
            {
                // Debug.Log("On Fire! " + burnerState.name);
                _cookedPercent += Time.deltaTime * 5;
                OnCookedChange.Invoke(_cookedPercent);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (_drawGizmo)
            Gizmos.DrawWireCube(transform.position, transform.localScale * _scale);
    }
}
