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

    public float costResilience; 
    
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
        if (skilltype == ActiveSkill.skillType.Physics && damage > 0.0f)
        {
            damage -= playerAR;
        }
        else if (skilltype == ActiveSkill.skillType.Magic && damage > 0.0f)
        {
            damage -= playerMR;
        }
        if (damage <= 0.0f) { damage = 0.0f; }
        playerHP -= damage;
        FloatingTextManager floatingtextmanagerscript = floatingtextmanager.GetComponent<FloatingTextManager>();
        //floatingtextmanagerscript.ShowFloatingText(GameManager.Instance.player.transform.position, damage);
        //여기에 체력바에 접근해서 체력바 깎는거
        PlayerHPBar.Instance.UpdatePlayerDamageBar(damage);

    }
    public float returnADAP(ActiveSkill.skillType skillType)
    {
        if (skillType == ActiveSkill.skillType.Physics)
        {
            return playerAD;
        }
        else if (skillType == ActiveSkill.skillType.Magic)
        {
            return playerAP;
        }
        return 0.0f;
    }


}
