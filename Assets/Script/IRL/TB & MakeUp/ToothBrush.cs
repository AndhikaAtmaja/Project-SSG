using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBrush : MonoBehaviour, IPickable
{
    [SerializeField] private Transform ToothBrushPalace;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = ToothBrushPalace.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPickUp()
    {

    }

    public void OnDrag(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

    public void OnDrop()
    {
        transform.position = ToothBrushPalace.position;
    }
}
