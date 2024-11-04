using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float playerHP;
    public float playerAD;
    public float playerAP;
    public float playerAR;
    public float playerMR;

    public float costResilience; // 코스트 회복력.

    private void Start()
    {
        playerHP = 100;
        playerAD = 5;
        playerAP = 5;
        playerMR = 5;
        playerAR = 5;

        costResilience = 140f;
    }
}
