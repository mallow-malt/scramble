using UnityEngine;
using UnityEngine.InputSystem;

[ExecuteInEditMode]
public class Grab : MonoBehaviour
{
    [SerializeField] private GameObject _openModel = null;
    [SerializeField] private GameObject _closedModel = null;

    public bool Closed = false;
    void Start()
    {
        PlayerControls controls = new PlayerControls();
        controls.RightHand.Enable();
        controls.RightHand.Grab.started += GrabStarted;
        controls.RightHand.Grab.canceled += GrabCanceled;
    }

    private void GrabStarted(InputAction.CallbackContext context)
    {
        if(context.started)
            Closed = true;
    }

    private void GrabCanceled(InputAction.CallbackContext context)
    {
        if(context.canceled)
            Closed = false;
    }

    void Update()
    {
        _openModel.SetActive(!Closed);
        _closedModel.SetActive(Closed);
    }
}
