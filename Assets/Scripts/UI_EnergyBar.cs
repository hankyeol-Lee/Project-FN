using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI_EnergyBar : MonoBehaviour
{
    public Image healthBar;           // ü�¹� Image ������Ʈ
    public Text healthText;           // ü���� ǥ���� Text ������Ʈ
    public float fillSpeed = 1f;      // 1�ʿ� �� ĭ�� �������� �ӵ�
    private int maxHealth = 10;       // �ִ� ü�� ĭ ��
    private int currentHealth;        // ���� ü�� ĭ ��
    private bool canDecreaseHealth = true; // ü�� ���� ���� ����

    void Start()
    {
        UpdateHealthBar();
        UpdateHealthText();           // �ʱ� �ؽ�Ʈ ������Ʈ
    }

    void Update()
    {
        // ü���� �ִ�ġ ������ �� 1�ʸ��� ü���� �� ĭ�� ����
        if (currentHealth < maxHealth)
        {
            healthBar.fillAmount += (1f / maxHealth) * (fillSpeed * Time.deltaTime);

            // ���� ĭ���� ä�������� Ȯ��
            if (healthBar.fillAmount >= (float)(currentHealth + 1) / maxHealth)
            {
                currentHealth += 1;
                UpdateHealthBar();
                UpdateHealthText();
            }
        }

        // Q Ű�� ������ ü�� ���Ұ� ������ ��� �� ĭ ����
        if (Input.GetKeyDown(KeyCode.Q) && canDecreaseHealth)
        {
            DecreaseHealth();
        }
    }

    // ü�� �� ĭ ���̴� �޼���
    void DecreaseHealth()
    {
        if (currentHealth > 0)
        {
            currentHealth -= 1;
            UpdateHealthBar();
            UpdateHealthText();
            Debug.Log("Q Ű�� ������ ü���� �� ĭ �پ����ϴ�. ���� ü��: " + currentHealth);

            // ü�� ���� �� ���� �ð� ���� Q �Է��� ��Ȱ��ȭ
            canDecreaseHealth = false;
            Invoke(nameof(EnableDecreaseHealth), 0.1f); // 0.1�� �� �Է� ��Ȱ��ȭ
        }
    }

    // ü�¹� ������Ʈ
    void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
    }
    void EnableDecreaseHealth()
    {
        canDecreaseHealth = true;
    }
    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString(); // �ؽ�Ʈ�� ���� ü�� ǥ��
        }
    }
}
