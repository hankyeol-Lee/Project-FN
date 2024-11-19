using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float playerHP;
    public float playerAD;
    public float playerAP;
    public float playerAR;
    public float playerMR;

    public float costResilience; // 코스트 회복력.

    public GameObject floatingtextmanager;

    private void Start()
    {
        playerHP = 100;
        playerAD = 5;
        playerAP = 5;
        playerMR = 5;
        playerAR = 5;

        costResilience = 140f;
    }
    public void PlayerGetDamage(float damage,ActiveSkill.skillType skilltype)
    {
        //플레이어 받는 데미지 계산식.
        if (skilltype == ActiveSkill.skillType.Physics && damage > 0.0f)
        {
            damage += playerAR;
        }
        else if (skilltype == ActiveSkill.skillType.Magic && damage > 0.0f)
        {
            damage += playerMR;
        }
        playerHP -= damage;
        Debug.Log("플레이어 체력 변동 : "+ playerHP);
        FloatingTextManager floatingtextmanagerscript = floatingtextmanager.GetComponent<FloatingTextManager>();
        floatingtextmanagerscript.ShowFloatingText(GameManager.Instance.player.transform.position, damage);

    }
    
}
