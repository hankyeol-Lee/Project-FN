using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSkill;
namespace Enemyspace // Enemyspace로 Enemy클래스에 접근 가능하도록 제어.
{
    public abstract class Enemy
    {
        // Enemy Class 안에 필요한 속성, 메소드 추가
        //TODO : 
        protected float HP;
        protected float AD;
        protected float AP;
        protected int AR; // 물리방어력. 
        protected int MR; // Magic Resistance, 마법저항력.
        protected float Speed; // 이동속도.

        public List<SkillData> skillDataList; // 적 개체가 쓸 skilldata의 list를 참조.
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
            // Enemy가 죽으면 공통적으로 하는 것들을 적으면 됨.

        }
    }

}
