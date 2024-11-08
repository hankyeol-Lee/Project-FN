using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillList // ������ �� ��ų�� ����� ����ִ� ��.
{
    public class MagicBullet : ActiveSkill
    {
        public MagicBullet(SkillData data) : base(data) {} // initializer
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell)
        {
            if (skillCaster.CompareTag("player"))
            {
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
            }
        }
    }




}
