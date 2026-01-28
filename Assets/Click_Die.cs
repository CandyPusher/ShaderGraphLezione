using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Click_Die : MonoBehaviour
{

    public Camera mainCamera;
    Vector2 mousePosition;

    public float maxDistance;
    public float vanishAmount;

    public void ActiveEffect(InputAction.CallbackContext obj)
    {
        DetectObject();
    }

    public void MousePositionSet(InputAction.CallbackContext obj)
    {
        mousePosition = obj.action.ReadValue<Vector2>();
    }

    Coroutine cor_vanish;

    private void DetectObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.transform.tag == "Hades" && cor_vanish == null)
            {
                Debug.Log("Hades");
                Renderer hitted = hit.transform.GetComponent<Renderer>();
                cor_vanish = StartCoroutine(VanishHades(hitted, vanishAmount));
            }
        }
    }

    private IEnumerator VanishHades(Renderer toDisappear, float vanishRate)
    {
        while (toDisappear.material.GetFloat("_DissolveAmount") < 1)
        {
            float amount = toDisappear.material.GetFloat("_DissolveAmount");
            amount += vanishRate * Time.deltaTime;
            toDisappear.material.SetFloat("_DissolveAmount", amount);
            yield return null;
        }
        Debug.Log("Finito");
        StopCoroutine(cor_vanish);
        cor_vanish = null;
        yield return null;
    }
}
