using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class miniMap_CameraPOS : MonoBehaviour
{
    private Transform Player_Pos;
    public Transform Camera_Pos;
    // Start is called before the first frame update
    void Start()
    {
        Player_Pos = GameObject.Find("Player").GetComponent<Transform>();
        Camera_Pos = GetComponent<Transform>();
        Camera_Pos.position = new Vector3(Player_Pos.position.x, Player_Pos.position.y, -6);
    }

    // Update is called once per frame
    void Update()
    {
        if (!miniMap_UI_Touch.is_MiniMap_Touch)
        {
            Camera_Pos.position = new Vector3(Player_Pos.position.x, Player_Pos.position.y, -6);
        }
        else
        {
            //Camera_Pos.position = new Vector3(Player_Pos.position.x + test_SCRIPT.delta_MiniMap_POS.x , Player_Pos.position.y + test_SCRIPT.delta_MiniMap_POS.y, -6);
            
        }
        
        
    }
}
