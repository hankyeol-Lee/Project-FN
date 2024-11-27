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
            //DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� ����
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
        // ü���� �ִ�ġ ������ �� 1�ʸ��� ü���� �� ĭ�� ����
        if (currentHealth < maxHealth)
        {
            healthBar.fillAmount += (1f / maxHealth) * (fillSpeed * Time.deltaTime);

            // ���� ĭ���� ä�������� Ȯ��
            if (healthBar.fillAmount >= (currentHealth + 1.0f) / maxHealth)
            {
                currentHealth += 1;
                UpdateHealthBar();
                UpdateHealthText();
            }
        }
        else //�ִ�ġ �̻��� ���
        {
            currentHealth = maxHealth;
            UpdateHealthBar();
            UpdateHealthText();
        }
/*
        // Q Ű�� ������ ü�� ���Ұ� ������ ��� �� ĭ ����
        if (Input.GetKeyDown(KeyCode.E) && canDecreaseHealth)
        {
            DecreaseHealth(2);
        }
*/
    }

    // ü�� �� ĭ ���̴� �޼���
    public void DecreaseHealth(int cost)
    {
        if (currentHealth > 0)
        {
            currentHealth -= cost;
            UpdateHealthBar();
            UpdateHealthText();
            //Debug.Log("Q Ű�� ������ ü���� �� ĭ �پ����ϴ�. ���� ü��: " + currentHealth);

            // ü�� ���� �� ���� �ð� ���� Q �Է��� ��Ȱ��ȭ
            canDecreaseHealth = false;
            Invoke(nameof(EnableDecreaseHealth), 0.1f); // 0.1�� �� �Է� ��Ȱ��ȭ
        }
    }
    public int GetPlayerEnergy()
    {
        return Mathf.FloorToInt(currentHealth); // �Ҽ��� ���ϸ� ������ ���� ��ȯ
    }
    // ü�¹� ������Ʈ
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
            healthText.text = ((int)currentHealth).ToString(); // �ؽ�Ʈ�� ���� ü�� ǥ��
        }
    }
}
