using UnityEngine;

public class GameCondition : MonoBehaviour
{
    public GameObject Player;
    public float P_Health; // �÷��̾��� ü��
    public float P_AD; // �÷��̾��� �������ݷ�
    public float P_AP; // �÷��̾��� �������ݷ�, ����
    public float P_AR; // �÷��̾��� ��������
    public float P_MR; // �÷��̾��� ��������
    public int Cur_Cost; // ���� �ڽ�Ʈ
    public float Cost_Fill; // �ڽ�Ʈ ȸ����



    private void Start()
    {
        P_Health = Player.GetComponent<PlayerStatus>().playerHP;
        P_AD = Player.GetComponent<PlayerStatus>().playerAD;
        P_AP = Player.GetComponent<PlayerStatus>().playerAP;
        P_AR = Player.GetComponent<PlayerStatus>().playerAR;
        P_MR = Player.GetComponent<PlayerStatus>().playerMR;
        Cur_Cost = UI_EnergyBar.Instance.currentHealth;
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
        P_Health = Player.GetComponent<PlayerStatus>().playerHP;
        P_AD = Player.GetComponent<PlayerStatus>().playerAD;
        P_AP = Player.GetComponent<PlayerStatus>().playerAP;
        P_AR = Player.GetComponent<PlayerStatus>().playerAR;
        P_MR = Player.GetComponent<PlayerStatus>().playerMR;
        Cur_Cost = UI_EnergyBar.Instance.currentHealth;
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
        

        Player.GetComponent<PlayerStatus>().playerHP = P_Health;
        Player.GetComponent<PlayerStatus>().playerAD = P_AD;
        Player.GetComponent<PlayerStatus>().playerAP = P_AP;
        Player.GetComponent<PlayerStatus>().playerAR = P_AR;
        Player.GetComponent<PlayerStatus>().playerMR = P_MR;
        UI_EnergyBar.Instance.currentHealth = Cur_Cost;
        UI_EnergyBar.Instance.fillSpeed = Cost_Fill;

        //Debug.Log(UI_EnergyBar.Instance.currentHealth);

    }
}