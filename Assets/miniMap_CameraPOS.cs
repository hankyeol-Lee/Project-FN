using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMap_CameraPOS : MonoBehaviour
{
    private Transform Player_Pos;
    public Transform Camera_Pos;
    // Start is called before the first frame update
    void Start()
    {
        Player_Pos = GameObject.Find("Player").GetComponent<Transform>();
        Camera_Pos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Camera_Pos.position = new Vector3(Player_Pos.position.x, Player_Pos.position.y, -6);   
    }
}
