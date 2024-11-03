using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class test_SCRIPT : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    /*
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
    */

    public Vector3 Default_MiniMap_Touch_POS;
    public Vector3 Current_MiniMap_Touch_POS;
    public static Vector2 delta_MiniMap_POS;
    public static bool is_MiniMap_Touch;

    // Start is called before the first frame update
    void Start()
    {
        is_MiniMap_Touch = false;
        Default_MiniMap_Touch_POS = GetComponent<RectTransform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("TEST_CLICK");
            //Current_MiniMap_Touch_POS = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -6);
            //delta_MiniMap_POS = new Vector2(Current_MiniMap_Touch_POS.x - Default_MiniMap_Touch_POS.x, Current_MiniMap_Touch_POS.y - Default_MiniMap_Touch_POS.y);
        }
        
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("TEST_DRAG_START");
        is_MiniMap_Touch = true;
        Current_MiniMap_Touch_POS = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -6);

    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Debug.Log("TEST_DRAG_ING");
        
        Debug.Log(eventData.position.x);
        Debug.Log(eventData.position.y);

        delta_MiniMap_POS = new Vector2( (eventData.position.x - Current_MiniMap_Touch_POS.x) / 100, (eventData.position.y - Current_MiniMap_Touch_POS.y) / 100);
        Current_MiniMap_Touch_POS = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -6);

        Debug.Log(delta_MiniMap_POS);

    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("TEST_DRAG_END");
        is_MiniMap_Touch = false;
    }
}
