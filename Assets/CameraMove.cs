using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    private bool isAnchored = true;

    private double dy = 20.14;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (isAnchored) 
        { 
            transform.position = new Vector3(player.transform.position.x , player.transform.position.y + (float)dy,transform.position.z); 
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space) && isAnchored)
        {
            isAnchored = false;
            Debug.Log("��������");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isAnchored)
        {
            isAnchored = true;
            Debug.Log("����");
        } */

        if(miniMap_UI_Touch.is_MiniMap_Touch) // �̴ϸ� ��ȣ�ۿ�
        {
            isAnchored = false; // �̴ϸ� ī�޶�UI ��ġ�� �����ؾ� �� �� // ���� ��ȭ�� ���� delta���� �̰� �ƴ� �����ؾ���
            transform.position = new Vector3(player.transform.position.x + miniMap_UI_Touch.delta_MiniMap_POS.x / 60, player.transform.position.y + miniMap_UI_Touch.delta_MiniMap_POS.y / 60 + (float)dy, transform.position.z);
        }else
        {
            isAnchored = true;
        }

    }
}
