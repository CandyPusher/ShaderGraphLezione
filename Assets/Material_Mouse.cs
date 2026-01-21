using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Material_Mouse : MonoBehaviour
{
    public Material mat;
    private void OnEnable()
    {
    }

    private void Start()
    {
    }

    public void SetVelMat(InputAction.CallbackContext obj)
    {
        mat.SetFloat("_Velocity", obj.ReadValue<float>());
        Debug.Log(obj.ReadValue<float>());
    }
}
