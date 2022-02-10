using UnityEngine;
using UnityEngine.InputSystem;

[ExecuteInEditMode]
public class RightHandControls : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Vector3 _moveHere;
    [SerializeField] private GameObject _openModel = null;
    [SerializeField] private GameObject _closedModel = null;

    [SerializeField] private bool _closed = false;

    [SerializeField] private HandleInPalm _handleInPalm = null;

    [SerializeField] private Rigidbody _fryingPan = null;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        PlayerControls controls = new PlayerControls();
        controls.RightHand.Enable();
        controls.RightHand.HandPosition.performed += HandPositionPerformed;
        controls.RightHand.Grab.started += GrabStarted;
        controls.RightHand.Grab.canceled += GrabCanceled;
    }

    private void HandPositionPerformed(InputAction.CallbackContext context)
    {
        if(context.performed) {
            _moveHere += context.ReadValue<Vector3>();
        }
    }

    private bool _isHoldingPan = false;

    private void HoldPan()
    {
        if (_isHoldingPan) return;

        var fj = gameObject.AddComponent<FixedJoint>();
        fj.connectedBody = _fryingPan;
        _isHoldingPan = true;
        _fryingPan.useGravity = false;
    }

    private void ReleasePan()
    {
        if (!_isHoldingPan) return;

        var fj = gameObject.GetComponent<FixedJoint>();
        Destroy(fj);
        _isHoldingPan = false;
        _fryingPan.useGravity = true;
    }

    private void GrabStarted(InputAction.CallbackContext context)
    {
        if(context.started){
            _closed = true;
            if (_handleInPalm.Colliding && !_isHoldingPan)
            {
                HoldPan();
            }
        }
    }

    private void GrabCanceled(InputAction.CallbackContext context)
    {
        if(context.canceled) {
            _closed = false;
            if (_isHoldingPan)
            {
                ReleasePan();
            }
        }
    }

    private void Update()
    {
        _openModel.SetActive(!_closed);
        _closedModel.SetActive(_closed);
    }

    private void FixedUpdate() {
        _rigidBody.AddForce(_moveHere);
        _moveHere = Vector3.zero;
    }
}
