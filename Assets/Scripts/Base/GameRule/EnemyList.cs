using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemyspace;
public class EnemyList
{
    // ���⿡ Enemy�� ���� class�� ����ϸ� ��. Enemy�� ���� ���� ��.
    public class Slime : Enemy
    {
        public Slime(EnemyData data) : base(data) { }
        /*
        public GiantRat(EnemyData data) { Initialize(data); }
        private void Initialize(EnemyData data)
        {
            try { 
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
            catch {
                Debug.Log($"{data.Name} : �Ҵ�� EnemyData�� �����ϴ�.");
            }
        }
        */
        public override void Attack()
        {
            
        }
        public override void AddSkill()
        {

        }


    }

   
}
