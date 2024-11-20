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

    public float costResilience; // �ڽ�Ʈ ȸ����.
    
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
    public void PlayerGetDamage(float damage,ActiveSkill.skillType skilltype) // �÷��̾�� �������� �ִ� �Լ�. ���⿡�� �ؽ�Ʈ �ִϸ��̼� ����
    {
        //�÷��̾� �޴� ������ ����.
        if (skilltype == ActiveSkill.skillType.Physics && damage > 0.0f)
        {
            damage += playerAR;
        }
        else if (skilltype == ActiveSkill.skillType.Magic && damage > 0.0f)
        {
            damage += playerMR;
        }
        playerHP -= damage;
        Debug.Log("�÷��̾� ü�� ���� : "+ playerHP);
        FloatingTextManager floatingtextmanagerscript = floatingtextmanager.GetComponent<FloatingTextManager>();
        floatingtextmanagerscript.ShowFloatingText(GameManager.Instance.player.transform.position, damage);

    }
    
}
