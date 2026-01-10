using UnityEngine;
using UnityEngine.InputSystem;

public class MovementCharacter : MonoBehaviour
{
    [SerializeField] private float speedMovement;
    [SerializeField] private Vector2 direction;

    public string walkingSoundEffect;

    private AnimationCharacter _animation;
    private bool isWalkingSoundPlaying;
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
        if (GameManager.instance.GetStatus("minigame") ||
            DialogueManager.instance.isDialogueActive())
        {
            StopWalkingSound();
            rb.velocity = Vector2.zero;
            return;
        }

        rb.velocity = direction * speedMovement;

        bool currentlyWalking = Mathf.Abs(direction.x) > 0.1f;

        if (currentlyWalking)
        {
            StartWalkingSound();
        }
        else if (!currentlyWalking)
        {
            StopWalkingSound();
        }
        _animation.WalkAnimation(direction);
    }

    private void StartWalkingSound()
    {
        if (isWalkingSoundPlaying) return;

        SoundManager.instance.PlayWalkingSoundEffect(walkingSoundEffect);
        isWalkingSoundPlaying = true;
    }

    private void StopWalkingSound()
    {
        isWalkingSoundPlaying = false;
        SoundManager.instance.StopWalkingSoundEffect();
    }
}
