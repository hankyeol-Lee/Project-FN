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
        public float HP;
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
        

        public virtual void TakeDamage(Transform position, float damage, ActiveSkill.skillType skilltype)
        {
            // 에너미의 마방 혹은 물리방어력으로 데미지 계산하고 HP 계산
            if (skilltype == ActiveSkill.skillType.Physics && damage > 0.0f)
            {
                damage -= AR;
            }
            else if (skilltype == ActiveSkill.skillType.Magic && damage > 0.0f)
            {
                damage -= MR;
            }

            // 데미지가 0 이하가 되지 않도록 제한
            if (damage <= 0.0f) { damage = 0.0f; }

            // 체력 감소
            HP -= damage;

            // 체력이 0 이하로 내려가지 않도록 제한
            if (HP < 0.0f)
            {
                HP = 0.0f;
            }

            Debug.Log($"Damage: {damage}, Remaining HP: {HP}");

            // 플로팅 텍스트 표시
            FloatingTextManager floatingtextmanagerscript = GameManager.Instance.floatingtextmanager.GetComponent<FloatingTextManager>();
            //floatingtextmanagerscript.ShowFloatingText(position.transform.position, damage);

            // 체력바 업데이트
            if (EnemyHPBar.enemyHPBars.TryGetValue(position.name, out EnemyHPBar hpBar))
            {
                hpBar.UpdateEnemyDamageBar();
            }

            // 체력이 0일 경우 사망 처리
            if (HP <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            // 적 이름 가져오기
            string enemyName = this.GetType().Name; // 또는 적의 고유 이름을 적절히 가져오는 로직

            // 1. 적의 HP Bar 제거
            if (EnemyHPBar.enemyHPBars.TryGetValue(enemyName, out EnemyHPBar hpBar))
            {
                hpBar.RemoveHPBar(); // EnemyHPBar 클래스에 체력바 제거 메서드 호출
            }

            // 2. 적 인스턴스를 게임에서 제거
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
                Debug.LogError($"{SkillName} 스킬이 존재하지 않습니다.");
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
