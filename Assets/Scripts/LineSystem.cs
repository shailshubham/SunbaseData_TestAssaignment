using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineSystem : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField]
    GameObject LineObject;

    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        if(LineObject!=null)
        {
            line = LineObject.GetComponent<LineRenderer>();
        }
        LineObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
