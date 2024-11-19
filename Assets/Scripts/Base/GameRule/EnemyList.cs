using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemyspace;
public class EnemyList
{
    // ���⿡ Enemy�� ���� class�� ����ϸ� ��. Enemy�� ���� ���� ��.
    public class Slime : Enemy
    {
        public Slime(EnemyData data) : base(data) // �����ڿ��� ��ų ����Ʈ�� ���� �̸���� �� �ν��Ͻ�, enemySkillList�� �߰� 
        {
            
        }

        public override void Attack(GameObject attacker)
        {
            Debug.Log("������� ��");
            enemySkillList[0].CastSkill(enemySkillList[0],attacker);
        }
        
    }
    public class GiantRat : Enemy
    {
        public GiantRat(EnemyData data) : base(data)
        {

        }
        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }
    public class GiantRat : Enemy
    {
        public GiantRat(EnemyData data) : base(data)
        {

        }
        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }

   
}
