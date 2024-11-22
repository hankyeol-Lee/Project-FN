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
        public float HP;
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
        

        public virtual void TakeDamage(Transform position,float damage,ActiveSkill.skillType skilltype)
        {
            // ���ʹ��� ���� Ȥ�� ������������ ������ ����ϰ� HP ���
            if (skilltype == ActiveSkill.skillType.Physics && damage > 0.0f)
            {
                damage -= AR;
            }
            else if (skilltype == ActiveSkill.skillType.Magic && damage > 0.0f)
            {
                damage -= MR;
            }
            if (damage <= 0.0f) { damage = 0.0f; }
            HP -= damage;
            Debug.Log(damage);
            FloatingTextManager floatingtextmanagerscript = GameManager.Instance.floatingtextmanager.GetComponent<FloatingTextManager>();
            //floatingtextmanagerscript.ShowFloatingText(position.transform.position, damage);
            if (EnemyHPBar.enemyHPBars.TryGetValue(position.name, out EnemyHPBar hpBar))
            {
                hpBar.UpdateEnemyDamageBar();
            }
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
        public float returnADAP(ActiveSkill.skillType skillType)
        {
            if(skillType == ActiveSkill.skillType.Physics)
            {
                return AD;
            }
            else if (skillType == ActiveSkill.skillType.Magic)
            {
                return AP;
            }
            return 0.0f;
        }
        
    }

}
