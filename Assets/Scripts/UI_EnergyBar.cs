using System;
using System.Collections;
using System.Collections.Generic;
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
        // 체력이 최대치 이하일 때 체력 증가
        if (currentHealth < maxHealth)
        {
            // fillAmount를 증가시킴
            healthBar.fillAmount += (fillSpeed / maxHealth) * Time.deltaTime;

            // fillAmount를 currentHealth로 변환
            currentHealth = healthBar.fillAmount * maxHealth;

            UpdateHealthBar();
            UpdateHealthText();
        }
        else
        {
            // 체력이 최대치 이상일 경우 동기화
            currentHealth = maxHealth;
            healthBar.fillAmount = 1.0f; // 최대치로 설정
            UpdateHealthBar();
            UpdateHealthText();
        }
    }

    // 체력 감소 메서드
    public void DecreaseHealth(float cost)
    {
        if (currentHealth > 0 && canDecreaseHealth)
        {
            // fillAmount를 감소시키고 currentHealth 동기화
            healthBar.fillAmount -= cost / maxHealth;
            currentHealth = healthBar.fillAmount * maxHealth;

            // 체력 값이 0 이하로 내려가지 않도록 제한
            if (currentHealth < 0)
            {
                currentHealth = 0;
                healthBar.fillAmount = 0;
            }

            UpdateHealthBar();
            UpdateHealthText();

            // 체력 감소 후 일정 시간 동안 Q 입력 비활성화
            canDecreaseHealth = false;
            Invoke(nameof(EnableDecreaseHealth), 0.1f);
        }
    }

    public int GetPlayerEnergy()
    {
        return Mathf.FloorToInt(currentHealth); // 정수로 반환
    }

    // 체력바 업데이트
    public void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth; // fillAmount 동기화
    }

    void EnableDecreaseHealth()
    {
        canDecreaseHealth = true;
    }

    public void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = Mathf.FloorToInt(currentHealth).ToString(); // 텍스트 업데이트
        }
    }
}
