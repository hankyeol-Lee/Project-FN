using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemyspace;
public class EnemyList
{
    // Slime Ŭ������
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
    // WeedSpirit Ŭ������
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
    // ���⿡ Enemy�� ���� class�� ����ϸ� ��. Enemy�� ���� ���� ��.
    public class Slime : Enemy
    {
        public Slime(EnemyData data) : base(data) // �����ڿ��� ��ų ����Ʈ�� ���� �̸���� �� �ν��Ͻ�, enemySkillList�� �߰� 
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
