using UnityEngine;
using UnityEngine.Events;

public class FireChecker : MonoBehaviour
{
    [SerializeField] private bool _drawGizmo = false;

    // Higher numbers = smaller colliders
    [SerializeField] private float _scale = 1f;
    public LayerMask Mask;
    public bool InFire = false;

    private void FixedUpdate()
    {
        Collider[] HitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale * (_scale / 2), Quaternion.identity, Mask);
        InFire = false;
        foreach (var Collider in HitColliders)
        {
            Fire burnerState = Collider.GetComponent<Fire>();
            if(burnerState.Active)
                InFire = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (_drawGizmo)
            Gizmos.DrawWireCube(transform.position, transform.localScale * _scale);
    }
}
