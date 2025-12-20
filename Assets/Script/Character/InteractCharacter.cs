using UnityEngine;
using UnityEngine.InputSystem;

public class InteractCharacter : MonoBehaviour
{
    [SerializeField] private IInteractable _interactable;

    public void InteractWithObject(InputAction.CallbackContext context)
    {
        if (context.performed && _interactable != null && !GameManager.instance.GetStatus("minigame"))
        {
            _interactable.interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable iinteracttable = other.GetComponent<IInteractable>();
        if (iinteracttable != null)
        {
            _interactable = iinteracttable;
        }
    }
}
