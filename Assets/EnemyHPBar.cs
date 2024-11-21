using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemyspace;
public class EnemyHPBar : MonoBehaviour
{
    private Transform healthBarTransform; // ü�¹� ������Ʈ�� Transform
    private Vector3 initialPosition; // ü�¹��� �ʱ� ��ġ

    public static EnemyHPBar Instance { get; private set; }
    private float currentHealth; // ���� ü��
    private float maxHealth; // �ִ� ü��
    public Enemy enemy;
    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        string parentEnemyName = transform.parent.name;
        EnemyInstances.enemyDict.TryGetValue(parentEnemyName, out enemy);
        healthBarTransform = transform;
        initialPosition = healthBarTransform.localPosition; // �ʱ� ��ġ ����

        if (enemy != null)
        {
            maxHealth = enemy.HP;
        }
        
    }

    public void UpdateEnemyDamageBar()
    {
        float healthRatio = enemy.HP / maxHealth;

        // ü�¹� ũ�� ���� (X�� ũ�� ����)
        Vector3 scale = healthBarTransform.localScale;
        scale.x = healthRatio; // ü�� ������ ���� ũ�� ����
        healthBarTransform.localScale = scale;

        // ü�¹� ��ġ ���� (�����ʿ��� �������� �پ���)
        Vector3 position = initialPosition;
        position.x = initialPosition.x - (1 - healthRatio) * scale.x * 0.5f;
        healthBarTransform.localPosition = position;
    }

}
