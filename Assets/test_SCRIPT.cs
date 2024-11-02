using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class test_SCRIPT : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector3 Current_MiniMap_Touch_POS;
    public static Vector2 delta_MiniMap_POS; 
    public static RectTransform MiniMap_UI_RT; // 미니맵 UI RectTransform

    public static bool is_MiniMap_Touch;
    public static bool is_MiniMap_dragging;

    void Start()
    {
        is_MiniMap_Touch = false;
        MiniMap_UI_RT = GetComponent<RectTransform>();
        
        MiniMap_UI_RT.sizeDelta = new Vector2(Screen.width * ((float)0.25), Screen.height * ((float)0.4)); // UI 사이즈 / 위치 초기화
        MiniMap_UI_RT.position = new Vector3(Screen.width -  MiniMap_UI_RT.sizeDelta.x / 2, (MiniMap_UI_RT.sizeDelta.y / 2), 0);

    }

    void Update()
    {
        if (!is_MiniMap_dragging && Input.GetMouseButtonDown(0) && (Screen.width - MiniMap_UI_RT.sizeDelta.x <= Input.mousePosition.x && Input.mousePosition.y <= MiniMap_UI_RT.sizeDelta.y))
        {
            Debug.Log("TEST_CLICK");
            Current_MiniMap_Touch_POS = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -6);
            delta_MiniMap_POS = new Vector2(Current_MiniMap_Touch_POS.x - MiniMap_UI_RT.position.x, Current_MiniMap_Touch_POS.y - MiniMap_UI_RT.position.y);
            is_MiniMap_Touch = true;

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
        Current_MiniMap_Touch_POS = new Vector3(eventData.position.x, eventData.position.y, -6);

    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Debug.Log("TEST_DRAG_ING");

        delta_MiniMap_POS = new Vector2(miniCamUI_test.miniMap_CamUI_POS.position.x - MiniMap_UI_RT.position.x, miniCamUI_test.miniMap_CamUI_POS.position.y - MiniMap_UI_RT.position.y);
        Current_MiniMap_Touch_POS = new Vector3(eventData.position.x, eventData.position.y, -6);

    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("TEST_DRAG_END");
        is_MiniMap_Touch = false;
        is_MiniMap_dragging = false;
    }
}
