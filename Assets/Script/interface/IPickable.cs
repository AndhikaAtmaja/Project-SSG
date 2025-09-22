using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    public void OnPickUp();

    public void OnDrag(Vector2 newPosition);

    public void OnDrop();
}
