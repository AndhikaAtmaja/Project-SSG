using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private List<Transform> points;

    public static PatternLine Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There are to Phone Manager is this game!");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    public void AddPoint(Transform point)
    {
        if (!points.Contains(point))
        {
            points.Add(point); 
            // Update line renderer
            lineRenderer.positionCount = points.Count; 
            lineRenderer.SetPosition(points.Count - 1, point.position); 
        }
    }

    public void ResetLinePattern() 
    {
        points.Clear(); lineRenderer.positionCount = 0; 
    }
}
