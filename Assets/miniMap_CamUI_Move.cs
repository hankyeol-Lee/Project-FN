using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMap_CamUI_Move : MonoBehaviour
{
    public static RectTransform miniMap_CamUI_POS;
    private UnityEngine.UI.Image miniMap_UI_Image;
    // Start is called before the first frame update
    void Start()
    {
        miniMap_CamUI_POS = GetComponent<RectTransform>();
        miniMap_UI_Image = GetComponent<UnityEngine.UI.Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (miniMap_UI_Touch.is_MiniMap_Touch)
        {
            miniMap_UI_Image.enabled = true;

            miniMap_CamUI_POS.position = new Vector3(Mathf.Clamp(miniMap_UI_Touch.Current_MiniMap_Touch_POS.x, Screen.width + miniMap_CamUI_POS.sizeDelta.x / 2 - miniMap_UI_Touch.MiniMap_UI_RT.sizeDelta.x, Screen.width), Mathf.Clamp(miniMap_UI_Touch.Current_MiniMap_Touch_POS.y, 0, miniMap_UI_Touch.MiniMap_UI_RT.sizeDelta.y - miniMap_CamUI_POS.sizeDelta.y / 2), -6);
        }
        else
        {
            miniMap_UI_Image.enabled = false;
        }
    }
}
