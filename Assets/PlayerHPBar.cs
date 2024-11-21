using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    public Image playerHpBar;
    private float currentHealth; // ���� ü��
    private float maxHealth = 100f; // �ִ� ü��

    public static PlayerHPBar Instance { get; private set; }
    public void Start()
    {
        Instance = this;
        playerHpBar = GetComponent<Image>();
        currentHealth = maxHealth; // �ʱ� ü���� �ִ� ü������ ����
        //UpdatePlayerHealthBar(100f); // ü�� �� �ʱ�ȭ
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
            currentHealth += heal; // ü���� ����
        }
        playerHpBar.fillAmount = currentHealth / maxHealth;
    }
}
