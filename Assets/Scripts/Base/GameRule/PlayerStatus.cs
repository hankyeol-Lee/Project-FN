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
    

    private void Start()
    {
        playerHP = 100;
        playerAD = 30;
        playerAP = 39;
        playerMR = 5;
        playerAR = 5;

        costResilience = 140f;
    }
    void OnSceneLoaded()
    {
        gameObject.SetActive(true);
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
        //floatingtextmanagerscript.ShowFloatingText(GameManager.Instance.player.transform.position, damage);
        //?—¬ê¸°ì— ì²´ë ¥ë°”ì— ? ‘ê·¼í•´?„œ ì²´ë ¥ë°? ê¹ŽëŠ”ê±?
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
