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
        protected List<string> enemySkillString; // SO에서 넣을 스킬 이름들.

        public List<ActiveSkill> enemySkillList; //실제로 에너미가 가지는 스킬 인스턴스의 리스트.

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
            // Enemy가 죽으면 공통적으로 하는 것들을 적으면 됨.

        }
        public void AddSkill(string SkillName)
        {
            if (!SkillInstance.skillInstances.ContainsKey(SkillName))
            {
                Debug.LogError($"{SkillName} 스킬이 존재하지 않습니다.");
                return;
            }
            if (SkillInstance.skillInstances.TryGetValue(SkillName, out ActiveSkill thisSkill))
            {
                enemySkillList.Add(thisSkill);
            }
        }
        
    }

}
