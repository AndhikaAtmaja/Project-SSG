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
            Cursor.visible = false;
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
            Cursor.visible = true;
    }

    private void OnMouseDown()
    {
        isHolding = !isHolding;
    }
}
