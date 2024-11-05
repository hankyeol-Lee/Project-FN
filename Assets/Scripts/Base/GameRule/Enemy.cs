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

        public List<SkillData> skillDataList; // �� ��ü�� �� skilldata�� list�� ����.
        protected List<Skill> skills = new List<Skill>();


        protected void Initialize(EnemyData data)
        {
            if (data != null)
            {
                this.HP = data.HP;
                this.AD = data.AD;
                this.AP = data.AP;
                this.AR = data.AR;
                this.MR = data.MR;
                this.Speed = data.Speed;

            }
        }

        public abstract void Attack();
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
    }

}
