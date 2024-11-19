using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemyspace;
public class EnemyList
{
    // 여기에 Enemy의 하위 class를 사용하면 됨. Enemy를 적어 놓을 듯.
    public class Slime : Enemy
    {
        public Slime(EnemyData data) : base(data) // 생성자에서 스킬 리스트에 적힌 이름들로 된 인스턴스, enemySkillList에 추가 
        {
            
        }

        public override void Attack(GameObject attacker)
        {
            Debug.Log("여기까지 됨");
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

   
}
