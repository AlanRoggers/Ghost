using UnityEngine;
using UnityEngine.InputSystem;
public class OnreActions : MonoBehaviour
{
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Saltando");
    }
}
