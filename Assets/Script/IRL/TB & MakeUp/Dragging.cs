using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    private bool isHolding;

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDown()
    {
        isHolding = !isHolding;
    }
}
