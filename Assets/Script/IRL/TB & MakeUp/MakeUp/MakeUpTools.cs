using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeUpTools : MonoBehaviour, IPickable
{
    public GameObject brush;

    public void OnPickUp()
    {
        Debug.Log($"Player pick {gameObject.name}");
        //change curso
        Cursor.visible = false;
        if (brush != null)
        {
            brush.SetActive(true);
        }
    }

    public void OnDrag(Vector2 newPosition)
    {
        brush.transform.position = newPosition;
    }

    public void OnDrop()
    {
        Debug.Log($"Player drop {gameObject.name}");
        Cursor.visible = true;
        brush.SetActive(false);
    }
}
