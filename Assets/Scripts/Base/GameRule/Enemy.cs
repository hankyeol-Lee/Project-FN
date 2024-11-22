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
        

        public virtual void TakeDamage(Transform position, float damage, ActiveSkill.skillType skilltype)
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

            // �������� 0 ���ϰ� ���� �ʵ��� ����
            if (damage <= 0.0f) { damage = 0.0f; }

            // ü�� ����
            HP -= damage;

            // ü���� 0 ���Ϸ� �������� �ʵ��� ����
            if (HP < 0.0f)
            {
                HP = 0.0f;
            }

            Debug.Log($"Damage: {damage}, Remaining HP: {HP}");

            // �÷��� �ؽ�Ʈ ǥ��
            FloatingTextManager floatingtextmanagerscript = GameManager.Instance.floatingtextmanager.GetComponent<FloatingTextManager>();
            //floatingtextmanagerscript.ShowFloatingText(position.transform.position, damage);

            // ü�¹� ������Ʈ
            if (EnemyHPBar.enemyHPBars.TryGetValue(position.name, out EnemyHPBar hpBar))
            {
                hpBar.UpdateEnemyDamageBar();
            }

            // ü���� 0�� ��� ��� ó��
            if (HP <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            // �� �̸� ��������
            string enemyName = this.GetType().Name; // �Ǵ� ���� ���� �̸��� ������ �������� ����

            // 1. ���� HP Bar ����
            if (EnemyHPBar.enemyHPBars.TryGetValue(enemyName, out EnemyHPBar hpBar))
            {
                hpBar.RemoveHPBar(); // EnemyHPBar Ŭ������ ü�¹� ���� �޼��� ȣ��
            }

            // 2. �� �ν��Ͻ��� ���ӿ��� ����
            if (SpawnEnemy.instance.enemyInstances.ContainsKey(enemyName))
            {
                SpawnEnemy.instance.EnemyEliminate(enemyName);
            }
 
            Debug.Log($"{enemyName} has been defeated and removed.");
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
