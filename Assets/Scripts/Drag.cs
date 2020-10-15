using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float mouseCoord;

    private void OnMouseDown()
    {
        mouseCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mouseOffset = gameObject.transform.position - GetMouseWoldPos();
    }



    private Vector3 GetMouseWoldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mouseCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWoldPos() + mouseOffset;
    }

}
