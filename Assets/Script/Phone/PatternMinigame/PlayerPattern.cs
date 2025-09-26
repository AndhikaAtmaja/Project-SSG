using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerPattern : MonoBehaviour
{
    [SerializeField] private List<GameObject> PlayerOrderPattern = new List<GameObject>();

    [SerializeField] private GraphicRaycaster raycaster;
    [SerializeField] private PointerEventData pointerEventData;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private bool isDrag;

    private void Start()
    {
        raycaster = FindObjectOfType<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();
    }

    private void Update()
    {
        if (isDrag)
        {
            HandelPlayerRaycast();
        }
    }

    public void OnHoldMouseButton(InputAction.CallbackContext context)
    {
        if (PhoneManager.Instance.GetPhoneStatus())
        {
            if (PhoneManager.Instance.CurrPhoneScreen().name == "Phone-LockScreen")
            {
                if (context.started)
                {
                    // Mouse Hold, Input pattern
                    isDrag = true;
                }
                else if (context.canceled)
                {
                    // Mouse released, check pattern
                    isDrag = false;
                    PatternMGManager.Instance.CheckPatternOrder(PlayerOrderPattern);
                }
            }
        }
    }

    void HandelPlayerRaycast()
    {
        pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = Mouse.current.position.ReadValue();

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag("Point"))
            {
                PatternPoint point = result.gameObject.GetComponent<PatternPoint>();
                if (point != null)
                {
                    if (PlayerOrderPattern.Count == 0)
                    {
                        point.ClickPoint();
                        PatternLine.Instance.AddPoint(point.transform);
                    }
                    else if (!PlayerOrderPattern.Contains(point.gameObject))
                    {
                        point.ConnectPoint(point.gameObject);
                        PlayerOrderPattern.Add(point.gameObject);
                        PatternLine.Instance.AddPoint(point.transform);
                    }
                }
            }
        }
    }

    public void AddFirstPoint(GameObject point)
    {
        if (PlayerOrderPattern.Count == 0)
        {
            PlayerOrderPattern.Add(point);
            Debug.Log("First point set: " + point.name);
        }
    }

    public void ResetPlayerPattern()
    {
        PlayerOrderPattern.Clear();
    }
}
