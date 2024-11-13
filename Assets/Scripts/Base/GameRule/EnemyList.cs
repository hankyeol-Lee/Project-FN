using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemyspace;
public class EnemyList
{
    // 여기에 Enemy의 하위 class를 사용하면 됨. Enemy를 적어 놓을 듯.
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
                Debug.Log($"{data.Name} : 할당된 EnemyData가 없습니다.");
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
