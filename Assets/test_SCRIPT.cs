using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class test_SCRIPT : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Vector3 Default_MiniMap_Touch_POS;
    public static Vector3 Current_MiniMap_Touch_POS;
    public static Vector2 delta_MiniMap_POS;
    public static bool is_MiniMap_Touch;
    public static bool is_MiniMap_dragging;

    private RectTransform MiniMap_UI_RT;

    // Start is called before the first frame update
    void Start()
    {
        is_MiniMap_Touch = false;
        //Default_MiniMap_Touch_POS = GetComponent<RectTransform>().position;
        MiniMap_UI_RT = GetComponent<RectTransform>();
        MiniMap_UI_RT.sizeDelta = new Vector2(Screen.width * ((float)0.25), Screen.height * ((float)0.4)); // UI 사이즈 / 위치 초기화
        MiniMap_UI_RT.position = new Vector3(Screen.width -  MiniMap_UI_RT.sizeDelta.x / 2, (MiniMap_UI_RT.sizeDelta.y / 2), 0);
        Debug.Log(MiniMap_UI_RT.sizeDelta.x / 2);

    }

    // Update is called once per frame
    void Update()
    {
        if (!is_MiniMap_dragging && Input.GetMouseButtonDown(0) && (Screen.width - MiniMap_UI_RT.sizeDelta.x <= Input.mousePosition.x && Input.mousePosition.y <= MiniMap_UI_RT.sizeDelta.y))
        {
            Debug.Log("TEST_CLICK");
            Current_MiniMap_Touch_POS = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -6);
            is_MiniMap_Touch = true;
            //delta_MiniMap_POS = new Vector2(Current_MiniMap_Touch_POS.x - Default_MiniMap_Touch_POS.x, Current_MiniMap_Touch_POS.y - Default_MiniMap_Touch_POS.y);
        } else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("TEST");
            is_MiniMap_Touch = false;
        }
        
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("TEST_DRAG_START");
        is_MiniMap_Touch = true;
        is_MiniMap_dragging = true;
        Current_MiniMap_Touch_POS = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -6);

    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Debug.Log("TEST_DRAG_ING");
       

        delta_MiniMap_POS = new Vector2( (eventData.position.x - Current_MiniMap_Touch_POS.x) / 100, (eventData.position.y - Current_MiniMap_Touch_POS.y) / 100);
        Current_MiniMap_Touch_POS = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -6);

        Debug.Log(delta_MiniMap_POS);

    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("TEST_DRAG_END");
        is_MiniMap_Touch = false;
        is_MiniMap_dragging = false;
    }
}
