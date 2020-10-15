using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public class Selector
    {
        public float Xmin;
        public float Xmax;
        public float Ymin;
        public float Ymax;

        public Selector(Vector3 start, Vector3 end)
        {
            Xmin = Mathf.Min(start.x, end.x);
            Xmax = Mathf.Max(start.x, end.x);
            Ymin = Mathf.Min(start.y, end.y);
            Ymax = Mathf.Max(start.y, end.y);
        }
    }

    private bool onDrawingRect;

    private Vector3 startPoint;
    private Vector3 currentPoint;
    private Vector3 endPoint;

    private Selector selector;


    public GUIStyle rectStyle;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            onDrawingRect = true;
            startPoint = Input.mousePosition;
            Debug.LogFormat("Start:{0}", startPoint);
        }

        if (onDrawingRect)
        {
            currentPoint = Input.mousePosition;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            endPoint = Input.mousePosition;
            onDrawingRect = false;
            Debug.LogFormat("End:{0}", endPoint);
            selector = new Selector(startPoint, endPoint);
            CheckSelection(selector, "Unit");
        }
    }

    
    void CheckSelection(Selector selector, string tag)
    {
        GameObject[] Units = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject Unit in Units)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(Unit.transform.position);
            if (screenPos.x > selector.Xmin && screenPos.x < selector.Xmax && screenPos.y > selector.Ymin && screenPos.y < selector.Ymax)
            {
                Debug.LogFormat("Choosen Tag:{0}", Unit.name);
            }
        }
    }

    void OnGUI()
    {
        if (onDrawingRect)
        {
            float Xmin = Mathf.Min(startPoint.x, currentPoint.x);
            float Xmax = Mathf.Max(startPoint.x, currentPoint.x);
            float Ymin = Mathf.Min(startPoint.y, currentPoint.y);
            float Ymax = Mathf.Max(startPoint.y, currentPoint.y);

            
            Rect rect = new Rect(Xmin, Screen.height - Ymax, Xmax - Xmin, Ymax - Ymin);
            GUI.Box(rect, "", rectStyle);
        }
    }
}
