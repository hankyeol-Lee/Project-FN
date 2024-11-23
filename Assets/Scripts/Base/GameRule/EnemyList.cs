using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemyspace;
public class EnemyList
{
    // Slime 클래스들
    public class Slime1 : Enemy
    {
        public Slime1(EnemyData data) : base(data) { }

        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }
    public class Slime2 : Enemy
    {
        public Slime2(EnemyData data) : base(data) { }

        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }
    public class Slime3 : Enemy
    {
        public Slime3(EnemyData data) : base(data) { }

        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }
    // WeedSpirit 클래스들
    public class WeedSpirit1 : Enemy
    {
        public WeedSpirit1(EnemyData data) : base(data) { }

        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }
    public class WeedSpirit2 : Enemy
    {
        public WeedSpirit2(EnemyData data) : base(data) { }

        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }
    public class WeedSpirit3 : Enemy
    {
        public WeedSpirit3(EnemyData data) : base(data) { }

        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }
    public class GiantRat1 : Enemy
    {
        public GiantRat1(EnemyData data) : base(data) { }

        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }
    public class GiantRat2 : Enemy
    {
        public GiantRat2(EnemyData data) : base(data) { }

        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }
    public class GiantRat3 : Enemy
    {
        public GiantRat3(EnemyData data) : base(data) { }

        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }

    public class Goblin1 : Enemy
    {
        public Goblin1(EnemyData data) : base(data) { }
        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }
    public class Goblin2 : Enemy
    {
        public Goblin2(EnemyData data) : base(data) { }
        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }
    public class Goblin3 : Enemy
    {
        public Goblin3(EnemyData data) : base(data) { }
        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }
    /// <summary>
    /// <summary>
    /// 
    /// <summary>
    /// //////
    /// </summary>
    // 여기에 Enemy의 하위 class를 사용하면 됨. Enemy를 적어 놓을 듯.
    public class Slime : Enemy
    {
        public Slime(EnemyData data) : base(data) // 생성자에서 스킬 리스트에 적힌 이름들로 된 인스턴스, enemySkillList에 추가 
        {
            
        }

        public override void Attack(GameObject attacker)
        {
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

    public class WeedSpirit : Enemy
    {
        public WeedSpirit(EnemyData data) : base(data)
        {

        }
        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }

    public class Goblin : Enemy
    {
        public Goblin(EnemyData data) : base(data)
        {

        }
        public override void Attack(GameObject attacker)
        {
            enemySkillList[0].CastSkill(enemySkillList[0], attacker);
        }
    }
}
