using UnityEngine;
using UnityEngine.InputSystem;

public class MovementCharacter : MonoBehaviour
{
    [SerializeField] private float speedMovement;
    [SerializeField] private Vector2 direction;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMovementCharacter(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.GetStatus("minigame"))
        {
            rb.velocity = direction * speedMovement;
        }
    }
}
