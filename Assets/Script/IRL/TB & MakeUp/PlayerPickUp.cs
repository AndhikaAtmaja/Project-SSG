using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private bool isHolding;
    private IPickable currentPickable;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (isHolding)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);

            Vector2 origin = worldPos;
            currentPickable.OnDrag(worldPos);
        }
    }

    public void OnPickingUp(InputAction.CallbackContext contex)
    {
        if (contex.started && !isHolding)
        {
            //Check curso is above an item and have IPickable
            Vector3 mousePos = Mouse.current.position.ReadValue();
            Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);

            Vector2 origin = worldPos;

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero);

            if (hit.collider != null)
            {
                IPickable pickable = hit.collider.GetComponent<IPickable>();
                if (pickable != null)
                {
                    currentPickable = pickable;
                    currentPickable.OnPickUp();
                    isHolding = true;
                }
            }
        }
        else if (contex.canceled && isHolding)
        {
            if (currentPickable != null)
            {
                currentPickable.OnDrop();
            }
            currentPickable = null;
            isHolding = false;
        }

    }
}
