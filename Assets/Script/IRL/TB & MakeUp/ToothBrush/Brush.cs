using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AreaBrushing"))
            Debug.Log("Inside tooth");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("AreaBrushing"))
            ToothBurshManager.instance.BrushingTooth();
    }
}
