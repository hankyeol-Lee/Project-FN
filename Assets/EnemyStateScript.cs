using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateScript : MonoBehaviour
{
    public EnemyState enemystate;
    public enum EnemyState
    {
        Wait,
        Move,
        Attack
    };
    private void OnEnable()
    {
        
    }


    private void Start()
    {
        OnEnable();
    }
}
