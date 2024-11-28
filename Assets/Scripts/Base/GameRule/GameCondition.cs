using UnityEngine;

public class GameCondition : MonoBehaviour
{
    public static GameCondition Instance;
    public float P_Health; // 플레이어의 체력
    public float P_AD; // 플레이어의 물리공격력
    public float P_AP; // 플레이어의 마법공격력, 마력
    public float P_AR; // 플레이어의 물리방어력
    public float P_MR; // 플레이어의 마법방어력
    public int Cur_Cost; // 현재 코스트
    public float Cost_Fill; // 코스트 회복력


    private void Awake()
    {
                if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Scene 전환 시 유지
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
            if(relic.Value == 0) // Relic value : 0 : 유물 효과 적용됨 / 1: 유물 효과 미적용됨
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
         //유물 추가, 효과 적용 테스트용 코드
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