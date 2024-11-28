using UnityEngine;

public class GameCondition : MonoBehaviour
{
    public static GameCondition Instance;
    public float P_Health; // �÷��̾��� ü��
    public float P_AD; // �÷��̾��� �������ݷ�
    public float P_AP; // �÷��̾��� �������ݷ�, ����
    public float P_AR; // �÷��̾��� ��������
    public float P_MR; // �÷��̾��� ��������
    public int Cur_Cost; // ���� �ڽ�Ʈ
    public float Cost_Fill; // �ڽ�Ʈ ȸ����


    private void Awake()
    {
                if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Scene ��ȯ �� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        
        P_Health = PlayerStatus.Instance.playerHP;
        P_AD = PlayerStatus.Instance.playerAD;
        P_AP = PlayerStatus.Instance.playerAP;
        P_AR = PlayerStatus.Instance.playerAR;
        P_MR = PlayerStatus.Instance.playerMR;
        Cur_Cost = (int)UI_EnergyBar.Instance.currentHealth;
        Cost_Fill = UI_EnergyBar.Instance.fillSpeed;
        
        foreach(var relic in RelicManager.Instance.activeRelicsDict)
        {
            if(relic.Value == 0) // Relic value : 0 : ���� ȿ�� ����� / 1: ���� ȿ�� �������
            {
                RelicManager.Instance.activeRelicsDict[relic.Key] = 1;
            }
        }
        RelicManager.Instance.CheckRelics(this);
        

    }

    private void Update()
    {
        P_Health = PlayerStatus.Instance.playerHP;
        P_AD = PlayerStatus.Instance.playerAD;
        P_AP = PlayerStatus.Instance.playerAP;
        P_AR = PlayerStatus.Instance.playerAR;
        P_MR = PlayerStatus.Instance.playerMR;
        Cur_Cost = (int)UI_EnergyBar.Instance.currentHealth;
        Cost_Fill = UI_EnergyBar.Instance.fillSpeed;

        RelicManager.Instance.CheckRelics(this);

        /*
         //���� �߰�, ȿ�� ���� �׽�Ʈ�� �ڵ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RelicManager.Instance.AddRelic("Emergency Charge");
            RelicManager.Instance.CheckRelics(this);
        }
        */
        

        PlayerStatus.Instance.playerHP = P_Health;
        PlayerStatus.Instance.playerAD = P_AD;
        PlayerStatus.Instance.playerAP = P_AP;
        PlayerStatus.Instance.playerAR = P_AR;
        PlayerStatus.Instance.playerMR = P_MR;
        UI_EnergyBar.Instance.currentHealth = Cur_Cost;
        UI_EnergyBar.Instance.fillSpeed = Cost_Fill;

        //Debug.Log(UI_EnergyBar.Instance.currentHealth);

    }
}