using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeUpTools : MonoBehaviour, IPickable
{
    public GameObject brush;

    private SpriteRenderer _sr;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void OnPickUp()
    {
        Debug.Log($"Player pick {gameObject.name}");
        //change curso
        Cursor.visible = false;
        if (brush != null)
        {
            if (brush != null)
            {
                MakeUpBrush makeUpBrush = brush.GetComponent<MakeUpBrush>();
                if (makeUpBrush != null)
                {
                    makeUpBrush.ChangeMakeUpBrush(_sr.sprite);
                }
            }
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
