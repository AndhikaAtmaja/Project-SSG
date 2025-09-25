using System.Collections;
using System.Collections.Generic;
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

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (direction.x * speedMovement, transform.position.y);
    }
}
