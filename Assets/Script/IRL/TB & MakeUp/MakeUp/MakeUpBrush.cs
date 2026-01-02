using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MakeUpBrush : MonoBehaviour
{

    private SpriteRenderer _sr;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeMakeUpBrush(Sprite makeUpSprite)
    {
        _sr.sprite = makeUpSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFace"))
        {
            Debug.Log("Make up the player face!");
            MakeUpManager.instance.AddApplyPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFace"))
        {
            Debug.Log("Done Make up the player face!");
        }
    }
}
