using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineManager : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    [SerializeField]
    GameObject LineObject;
    Camera cam;
    RectTransform rect;

    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rect = GetComponent<RectTransform>();
        if(LineObject!=null)
        {
            line = LineObject.GetComponent<LineRenderer>();
        }
        LineObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        LineObject.SetActive(true);
        Vector3 wp0;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position,cam, out wp0);
        line.SetPosition(0,wp0);
        Vector3 wp1;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, cam, out wp1);
        line.SetPosition(1, wp1);
        Debug.Log("Pointer is Down");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 wp1;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, cam, out wp1);
        line.SetPosition(1, wp1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector3 wp1;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, cam, out wp1);
        line.SetPosition(1, wp1);
        RaycastHit2D[] hits = Physics2D.LinecastAll(line.GetPosition(0), line.GetPosition(1));
        foreach(RaycastHit2D hit in hits)
        {
            hit.transform.gameObject.SetActive(false);
        }

    }
}
