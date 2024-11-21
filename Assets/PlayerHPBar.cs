using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    public Image playerHpBar;
    private float currentHealth; // 현재 체력
    private float maxHealth = 100f; // 최대 체력

    public static PlayerHPBar Instance { get; private set; }
    public void Start()
    {
        Instance = this;
        playerHpBar = GetComponent<Image>();
        currentHealth = maxHealth; // 초기 체력을 최대 체력으로 설정
        //UpdatePlayerHealthBar(100f); // 체력 바 초기화
    }

    public void UpdatePlayerDamageBar(float damage)
    {
        currentHealth -= damage;
        playerHpBar.fillAmount = currentHealth / maxHealth;
    }
    public void UpdatePlayerHealBar(float heal)
    {
        if (currentHealth + heal > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += heal; // 체력을 증가
        }
        playerHpBar.fillAmount = currentHealth / maxHealth;
    }
}
