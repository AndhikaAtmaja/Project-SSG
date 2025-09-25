using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LikeButton : MonoBehaviour
{
    private Image img;
    private bool isLiked;
    [SerializeField] private Color defaultColor;

    private void Start()
    {
        img = GetComponent<Image>();
        defaultColor = img.color;
    }

    public void GetLiked()
    {
        if (!isLiked)
        {
            img.color = Color.red;
            isLiked = true;
        }
        else
        {
            img.color = defaultColor;
            isLiked = false;
        }
    }
}
