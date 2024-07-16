using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_bar : MonoBehaviour
{
    public float Energy = 0f;
    public float changeAmountEnergy = 0.01f;
    float initialPositionX;
    float initialPositionY;
    Transform Tr;
    SpriteRenderer Sr;
    void Start()
    {
        Tr = GetComponent<Transform>();
        Sr = GetComponent<SpriteRenderer>();
        initialPositionX = transform.position.x;
        initialPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Energy = Energy + changeAmountEnergy;
        Sr.size = new Vector2(Energy, 2f);
        Tr.position = new Vector3(initialPositionX + (Energy * 0.5f), initialPositionY, transform.position.z);
    }
}
