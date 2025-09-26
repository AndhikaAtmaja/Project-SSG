using UnityEngine;
using UnityEngine.InputSystem;

public class Hair : MonoBehaviour
{
    public void StylingHair()
    {
        gameObject.SetActive(false);
        HairStyleManager.Instance.AddPlayerCount();
        Debug.Log($"{gameObject.name} is get styled!");
    }

    //public void GetClicked(InputAction.CallbackContext context)
    //{
    //    if (context.performed)
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
}
