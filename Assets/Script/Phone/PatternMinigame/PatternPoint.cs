using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternPoint : MonoBehaviour
{
    [Header("Config Point")]
    [SerializeField] private float speedRotation;
    [SerializeField] private GameObject ConnectToPoint;
    [SerializeField] private bool isSelected;

    private Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
/*        if (isSelected)
        {
            AutoRotatePoint();
        }*/
    }

    public void ClickPoint()
    {
        isSelected = true;
        PlayerPattern.Instance.AddFirstPoint(gameObject);
        img.color = Color.red;
    }

    public void ConnectPoint(GameObject point)
    {
        if (ConnectToPoint == null)
        {
            ConnectToPoint = point;
            img.color = Color.yellow;
            Debug.Log($"this {gameObject.name} is succes connect to {point.name}");
        }
    }

    public void AutoRotatePoint()
    {
        Debug.Log("Try to rotate!");
    }

    public void ResetPoint()
    {
        img.color = Color.white;
        ConnectToPoint = null;
    }
}
