using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_EnergyBar : MonoBehaviour
{
    public Image healthBar;           // 체력바 Image 컴포넌트
    public Text healthText;           // 체력을 표시할 Text 컴포넌트
    public float fillSpeed = 1.0f;      // 1초에 한 칸씩 차오르는 속도
    private float maxHealth = 10.0f;       // 최대 체력 칸 수
    public float currentHealth;        // 현재 체력 칸 수
    private bool canDecreaseHealth = true; // 체력 감소 가능 여부
    public static UI_EnergyBar Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // 씬 전환 시에도 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateHealthBar();
        UpdateHealthText();           // 초기 텍스트 업데이트
    }

    void Update()
    {
        // 체력이 최대치 이하일 때 1초마다 체력을 한 칸씩 증가
        if (currentHealth < maxHealth)
        {
            healthBar.fillAmount += (1f / maxHealth) * (fillSpeed * Time.deltaTime);

            // 다음 칸으로 채워졌는지 확인
            if (healthBar.fillAmount >= (currentHealth + 1.0f) / maxHealth)
            {
                currentHealth += 1;
                UpdateHealthBar();
                UpdateHealthText();
            }
        }
        else //최대치 이상인 경우
        {
            currentHealth = maxHealth;
            UpdateHealthBar();
            UpdateHealthText();
        }
/*
        // Q 키를 눌렀고 체력 감소가 가능한 경우 한 칸 감소
        if (Input.GetKeyDown(KeyCode.E) && canDecreaseHealth)
        {
            DecreaseHealth(2);
        }
*/
    }

    // 체력 한 칸 줄이는 메서드
    public void DecreaseHealth(int cost)
    {
        if (currentHealth > 0)
        {
            currentHealth -= cost;
            UpdateHealthBar();
            UpdateHealthText();
            //Debug.Log("Q 키가 눌려서 체력이 한 칸 줄었습니다. 현재 체력: " + currentHealth);

            // 체력 감소 후 일정 시간 동안 Q 입력을 비활성화
            canDecreaseHealth = false;
            Invoke(nameof(EnableDecreaseHealth), 0.1f); // 0.1초 후 입력 재활성화
        }
    }
    public int GetPlayerEnergy()
    {
        return Mathf.FloorToInt(currentHealth); // 소숫점 이하를 버리고 정수 반환
    }
    // 체력바 업데이트
    public void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
    void EnableDecreaseHealth()
    {
        canDecreaseHealth = true;
    }
   public void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = ((int)currentHealth).ToString(); // 텍스트에 현재 체력 표시
        }
    }
}
