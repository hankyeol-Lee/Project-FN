using System.Collections.Generic;
using UnityEngine;
using Enemyspace;

public class EnemyHPBar : MonoBehaviour
{
    private Transform healthBarTransform; // ü�¹� ������Ʈ�� Transform
    private Vector3 initialPosition; // ü�¹��� �ʱ� ��ġ

    private float currentHealth; // ���� ü��
    private float maxHealth; // �ִ� ü��
    private Vector3 Fscale;
    public Enemy enemy; // ����� Enemy ��ü

    // �θ� �̸��� Ű�� ����Ͽ� ü�¹� ����
    public static Dictionary<string, EnemyHPBar> enemyHPBars = new Dictionary<string, EnemyHPBar>();

    private void Start()
    {
        string parentEnemyName = transform.parent.name;

        // �θ� �̸����� ü�¹� ���
        if (!enemyHPBars.ContainsKey(parentEnemyName))
        {
            enemyHPBars.Add(parentEnemyName, this);
        }

        EnemyInstances.enemyDict.TryGetValue(parentEnemyName, out enemy);
        healthBarTransform = transform;
        Fscale = healthBarTransform.localScale;
        initialPosition = healthBarTransform.localPosition; // �ʱ� ��ġ ����

        if (enemy != null)
        {
            maxHealth = enemy.HP;
            currentHealth = maxHealth;
        }
    }

    public void UpdateEnemyDamageBar()
    {
        if (enemy == null) return;

        float healthRatio = enemy.HP / maxHealth;

        // ü�¹� ũ�� ���� (X�� ũ�� ����)
        Vector3 scale = healthBarTransform.localScale;
        scale.x = healthRatio * Fscale.x;
        healthBarTransform.localScale = scale;

        // ü�¹� ��ġ ���� (�����ʿ��� �������� �پ���)
        Vector3 position = initialPosition;
        position.x = initialPosition.x - (1 - healthRatio) * scale.x * 0.5f;
        healthBarTransform.localPosition = position;

        Debug.Log($"�̸� : {transform.parent.name} {enemy.HP} {maxHealth}");
    }

    // Ư�� ü�¹� ��ȯ �޼���
    public static EnemyHPBar GetHPBar(string parentEnemyName)
    {
        if (enemyHPBars.TryGetValue(parentEnemyName, out EnemyHPBar hpBar))
        {
            return hpBar;
        }
        Debug.LogWarning($"EnemyHPBar for {parentEnemyName} not found!");
        return null;
    }

    private void OnDestroy()
    {
        // ü�¹ٰ� �����Ǹ� ��ųʸ����� ����
        string parentEnemyName = transform.parent.name;
        if (enemyHPBars.ContainsKey(parentEnemyName))
        {
            enemyHPBars.Remove(parentEnemyName);
        }
    }
}