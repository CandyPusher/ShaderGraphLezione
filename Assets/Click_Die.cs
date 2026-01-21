using UnityEngine;
using UnityEngine.InputSystem;

public class Click_Die : MonoBehaviour
{

    public Camera mainCamera;
    public InputActionReference mouse_pos;
    Vector2 mousePosition;

    private void Start()
    {

    }

    private void Update()
    {
        mousePosition = mouse_pos.action.ReadValue<Vector2>();
    }

    public void ActiveEffect(InputAction.CallbackContext obj)
    {
        Ray ray1 = mainCamera.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray1, out RaycastHit info);
    }
}
