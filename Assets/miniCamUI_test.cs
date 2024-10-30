using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class miniCamUI_test : MonoBehaviour
{
    public RectTransform miniMap_CamUI_POS;
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
        //Debug.Log(Screen.width);
        //Debug.Log(Screen.height);
        if (test_SCRIPT.is_MiniMap_Touch)
        {
            miniMap_UI_Image.enabled = true;
            miniMap_CamUI_POS.position = new Vector3(test_SCRIPT.Current_MiniMap_Touch_POS.x, test_SCRIPT.Current_MiniMap_Touch_POS.y, -6);
            Debug.Log(miniMap_CamUI_POS.position);
        }
        else
        {
            miniMap_UI_Image.enabled = false;
        }
        
    }



}
