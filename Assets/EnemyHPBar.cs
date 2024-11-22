using System.Collections.Generic;
using UnityEngine;
using Enemyspace;

public class EnemyHPBar : MonoBehaviour
{
    private Transform healthBarTransform; // 체력바 오브젝트의 Transform
    private Vector3 initialPosition; // 체력바의 초기 위치

    private float currentHealth; // 현재 체력
    private float maxHealth; // 최대 체력
    private Vector3 Fscale;
    public Enemy enemy; // 연결된 Enemy 객체

    // 부모 이름을 키로 사용하여 체력바 관리
    public static Dictionary<string, EnemyHPBar> enemyHPBars = new Dictionary<string, EnemyHPBar>();

    private void Start()
    {
        string parentEnemyName = transform.parent.name;

        // 부모 이름으로 체력바 등록
        if (!enemyHPBars.ContainsKey(parentEnemyName))
        {
            enemyHPBars.Add(parentEnemyName, this);
        }

        EnemyInstances.enemyDict.TryGetValue(parentEnemyName, out enemy);
        healthBarTransform = transform;
        Fscale = healthBarTransform.localScale;
        initialPosition = healthBarTransform.localPosition; // 초기 위치 저장

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

        // 체력바 크기 조정 (X축 크기 변경)
        Vector3 scale = healthBarTransform.localScale;
        scale.x = healthRatio * Fscale.x;
        healthBarTransform.localScale = scale;

        // 체력바 위치 조정 (오른쪽에서 왼쪽으로 줄어들게)
        Vector3 position = initialPosition;
        position.x = initialPosition.x - (1 - healthRatio) * scale.x * 0.5f;
        healthBarTransform.localPosition = position;

        Debug.Log($"이름 : {transform.parent.name} {enemy.HP} {maxHealth}");
    }

    // 특정 체력바 반환 메서드
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
        // 체력바가 삭제되면 딕셔너리에서 제거
        string parentEnemyName = transform.parent.name;
        if (enemyHPBars.ContainsKey(parentEnemyName))
        {
            enemyHPBars.Remove(parentEnemyName);
        }
    }
}