using UnityEngine;
using UnityEngine.InputSystem;

[ExecuteInEditMode]
public class LeftHandControls : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Vector3 _moveHere;
    [SerializeField] private GameObject _openModel = null;
    [SerializeField] private GameObject _closedModel = null;

    [SerializeField] private bool _closed = false;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        PlayerControls controls = new PlayerControls();
        controls.LeftHand.Enable();
        controls.LeftHand.HandPosition.performed += HandPositionPerformed;
        controls.LeftHand.Grab.started += GrabStarted;
        controls.LeftHand.Grab.canceled += GrabCanceled;
    }

    private void HandPositionPerformed(InputAction.CallbackContext context)
    {
        if(context.performed) {
            _moveHere = context.ReadValue<Vector3>();
        }
    }

    private void GrabStarted(InputAction.CallbackContext context)
    {
        if(context.started)
            _closed = true;
    }

    private void GrabCanceled(InputAction.CallbackContext context)
    {
        if(context.canceled)
            _closed = false;
    }

    private void Update()
    {
        _openModel.SetActive(!_closed);
        _closedModel.SetActive(_closed);
    }

    private void FixedUpdate() {
        if(_moveHere == Vector3.zero)
            _rigidBody.velocity = Vector3.zero;
        else
            _rigidBody.AddForce(_moveHere);
    }
}
