using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EnergyBar : MonoBehaviour
{
    public Image healthBar;           // ü�¹� Image ������Ʈ
    public Text healthText;           // ü���� ǥ���� Text ������Ʈ
    public float fillSpeed = 1.0f;      // 1�ʿ� �� ĭ�� �������� �ӵ�
    private float maxHealth = 10.0f;       // �ִ� ü�� ĭ ��
    public float currentHealth;        // ���� ü�� ĭ ��
    private bool canDecreaseHealth = true; // ü�� ���� ���� ����
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
        UpdateHealthText();           // �ʱ� �ؽ�Ʈ ������Ʈ
    }

    void Update()
    {
        // ü���� �ִ�ġ ������ �� ü�� ����
        if (currentHealth < maxHealth)
        {
            // fillAmount�� ������Ŵ
            healthBar.fillAmount += (fillSpeed / maxHealth) * Time.deltaTime;

            // fillAmount�� currentHealth�� ��ȯ
            currentHealth = healthBar.fillAmount * maxHealth;

            UpdateHealthBar();
            UpdateHealthText();
        }
        else
        {
            // ü���� �ִ�ġ �̻��� ��� ����ȭ
            currentHealth = maxHealth;
            healthBar.fillAmount = 1.0f; // �ִ�ġ�� ����
            UpdateHealthBar();
            UpdateHealthText();
        }
    }

    // ü�� ���� �޼���
    public void DecreaseHealth(float cost)
    {
        if (currentHealth > 0 && canDecreaseHealth)
        {
            // fillAmount�� ���ҽ�Ű�� currentHealth ����ȭ
            healthBar.fillAmount -= cost / maxHealth;
            currentHealth = healthBar.fillAmount * maxHealth;

            // ü�� ���� 0 ���Ϸ� �������� �ʵ��� ����
            if (currentHealth < 0)
            {
                currentHealth = 0;
                healthBar.fillAmount = 0;
            }

            UpdateHealthBar();
            UpdateHealthText();

            // ü�� ���� �� ���� �ð� ���� Q �Է� ��Ȱ��ȭ
            canDecreaseHealth = false;
            Invoke(nameof(EnableDecreaseHealth), 0.1f);
        }
    }

    public int GetPlayerEnergy()
    {
        return Mathf.FloorToInt(currentHealth); // ������ ��ȯ
    }

    // ü�¹� ������Ʈ
    public void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth; // fillAmount ����ȭ
    }

    void EnableDecreaseHealth()
    {
        canDecreaseHealth = true;
    }

    public void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = Mathf.FloorToInt(currentHealth).ToString(); // �ؽ�Ʈ ������Ʈ
        }
    }
}
