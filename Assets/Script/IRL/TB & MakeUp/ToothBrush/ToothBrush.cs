using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBrush : MonoBehaviour, IPickable
{
    [SerializeField] private Transform ToothBrushPalace;
    private bool isPickUp;

    public static ToothBrush instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = ToothBrushPalace.position;
    }


    public void OnPickUp()
    {
        
    }

    public void OnDrag(Vector2 newPosition)
    {
        transform.position = newPosition;
        isPickUp = true;
    }

    public void OnDrop()
    {
        transform.position = ToothBrushPalace.position;
        isPickUp = false;
    }

    public bool GetIsPickUp()
    {
        return isPickUp;
    }
}
