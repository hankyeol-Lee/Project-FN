using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemyspace;
public class EnemyHPBar : MonoBehaviour
{
    private Transform healthBarTransform; // 체력바 오브젝트의 Transform
    private Vector3 initialPosition; // 체력바의 초기 위치

    public static EnemyHPBar Instance { get; private set; }
    private float currentHealth; // 현재 체력
    private float maxHealth; // 최대 체력
    public Enemy enemy;
    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        string parentEnemyName = transform.parent.name;
        EnemyInstances.enemyDict.TryGetValue(parentEnemyName, out enemy);
        healthBarTransform = transform;
        initialPosition = healthBarTransform.localPosition; // 초기 위치 저장

        if (enemy != null)
        {
            maxHealth = enemy.HP;
        }
        
    }

    public void UpdateEnemyDamageBar()
    {
        float healthRatio = enemy.HP / maxHealth;

        // 체력바 크기 조정 (X축 크기 변경)
        Vector3 scale = healthBarTransform.localScale;
        scale.x = healthRatio; // 체력 비율에 따라 크기 설정
        healthBarTransform.localScale = scale;

        // 체력바 위치 조정 (오른쪽에서 왼쪽으로 줄어들게)
        Vector3 position = initialPosition;
        position.x = initialPosition.x - (1 - healthRatio) * scale.x * 0.5f;
        healthBarTransform.localPosition = position;
    }

}
