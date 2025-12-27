using UnityEngine;
using UnityEngine.InputSystem;

public class MovementCharacter : MonoBehaviour
{
    [SerializeField] private float speedMovement;
    [SerializeField] private Vector2 direction;

    private AnimationCharacter _animation;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animation = GetComponent<AnimationCharacter>();
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
            _animation.WalkAnimation(direction);
        }
    }
}
