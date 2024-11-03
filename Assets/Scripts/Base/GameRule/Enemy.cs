using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Enemyspace // Enemyspace로 Enemy클래스에 접근 가능하도록 제어.
{
    public abstract class Enemy
    {
        // Enemy Class 안에 필요한 속성, 메소드 추가
        //TODO : 
        public float HP;
        public float AD;
        public float AP;
        public int AR; // 물리방어력. 
        public int MR; // Magic Resistance, 마법저항력.

        public float Speed; // 이동속도.

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
