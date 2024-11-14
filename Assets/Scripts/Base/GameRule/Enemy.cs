using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSkill;
namespace Enemyspace // Enemyspace�� EnemyŬ������ ���� �����ϵ��� ����.
{
    public abstract class Enemy
    {
        // Enemy Class �ȿ� �ʿ��� �Ӽ�, �޼ҵ� �߰�
        //TODO : 
        protected float HP;
        protected float AD;
        protected float AP;
        protected int AR; // ��������. 
        protected int MR; // Magic Resistance, �������׷�.
        protected float Speed; // �̵��ӵ�.
        protected List<string> enemySkillString; // SO���� ���� ��ų �̸���.

        public List<ActiveSkill> enemySkillList; //������ ���ʹ̰� ������ ��ų �ν��Ͻ��� ����Ʈ.

        public Enemy(EnemyData data)
        {
            if (data != null)
            {
                this.HP = data.HP;
                this.AD = data.AD;
                this.AP = data.AP;
                this.AR = data.AR;
                this.MR = data.MR;
                this.Speed = data.Speed;
                this.enemySkillString = data.enemySkillString;

                enemySkillList = new List<ActiveSkill>();

                foreach (var name in enemySkillString)
                {
                    AddSkill(name);
                }
            }
        }

        public abstract void Attack(GameObject attacker);
        

        public virtual void TakeDamage(float damage)
        {
            HP -= damage;
            if (HP < 0)
            {
                Die();
            }
        }
        protected virtual void Die()
        {
            // Enemy�� ������ ���������� �ϴ� �͵��� ������ ��.

        }
        public void AddSkill(string SkillName)
        {
            if (!SkillInstance.skillInstances.ContainsKey(SkillName))
            {
                Debug.LogError($"{SkillName} ��ų�� �������� �ʽ��ϴ�.");
                return;
            }
            if (SkillInstance.skillInstances.TryGetValue(SkillName, out ActiveSkill thisSkill))
            {
                enemySkillList.Add(thisSkill);
            }
        }
        
    }

}
