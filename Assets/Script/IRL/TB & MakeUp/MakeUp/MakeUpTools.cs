using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeUpTools : MonoBehaviour, IPickable
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(Vector2 newPosition)
    {
        
    }

    public void OnDrop()
    {
        Debug.Log($"Player drop {gameObject.name}");
    }

    public void OnPickUp()
    {
        Debug.Log($"Player pick {gameObject.name}");
        //change curso
    }
}
