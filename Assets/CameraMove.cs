using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    private bool isAnchored = true;

    private double dx = 1.9;
    private double dy = 20.14;
    private double dz = -17.36;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (isAnchored) 
        { 
            transform.position = new Vector3(player.transform.position.x , player.transform.position.y + (float)dy,transform.position.z); 
        }
        if (Input.GetKeyDown(KeyCode.Space) && isAnchored)
        {
            isAnchored = false;
            Debug.Log("고정해제");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isAnchored)
        {
            isAnchored = true;
            Debug.Log("고정");
        }
    }
}
