using UnityEngine;
using UnityEngine.InputSystem;

public class InteractCharacter : MonoBehaviour
{
    [SerializeField] private IInteractable _interactable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractWithObject(InputAction.CallbackContext context)
    {
        if (context.performed && _interactable != null)
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
