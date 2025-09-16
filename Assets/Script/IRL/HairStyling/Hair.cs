using UnityEngine;
using UnityEngine.InputSystem;

public class Hair : MonoBehaviour
{
    public void GetClicked(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            gameObject.SetActive(false);
        }
    }
}
