using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Enemyspace // Enemyspace�� EnemyŬ������ ���� �����ϵ��� ����.
{
    public abstract class Enemy
    {
        // Enemy Class �ȿ� �ʿ��� �Ӽ�, �޼ҵ� �߰�
        //TODO : 
        public float HP;
        public float AD;
        public float AP;
        public int AR; // ��������. 
        public int MR; // Magic Resistance, �������׷�.

        public float Speed; // �̵��ӵ�.

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
