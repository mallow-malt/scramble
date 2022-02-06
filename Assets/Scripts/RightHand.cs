using UnityEngine;
using UnityEngine.InputSystem;

public class RightHand : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveHere;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerControls controls = new PlayerControls();
        controls.RightHand.Enable();
        controls.RightHand.RightHandPosition.performed += RightHandPositionPerformed;
    }

    private void RightHandPositionPerformed(InputAction.CallbackContext context)
    {
        if(context.performed) {
            moveHere += context.ReadValue<Vector3>();
        }
    }

    private void FixedUpdate() {
        rb.AddForce(moveHere);
        moveHere = Vector3.zero;
    }
}
