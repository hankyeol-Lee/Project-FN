using UnityEngine;

public class GameCondition : MonoBehaviour
{
    /*
    public int CurrentCost { get; set; }
    public int PlayerHealth { get; set; }
    */
    public GameObject Player;
    public float P_Health;
    public float P_AD;
    public float P_AP;
    public float P_AR;
    public float P_MR;
    public int Cur_Cost;
    public float Cost_Fill;



    private void Start()
    {
        P_Health = Player.GetComponent<PlayerStatus>().playerHP;
        P_AD = Player.GetComponent<PlayerStatus>().playerAD;
        P_AP = Player.GetComponent<PlayerStatus>().playerAP;
        P_AR = Player.GetComponent<PlayerStatus>().playerAR;
        P_MR = Player.GetComponent<PlayerStatus>().playerMR;
        Cur_Cost = UI_EnergyBar.Instance.currentHealth;
        Cost_Fill = UI_EnergyBar.Instance.fillSpeed;
        //RelicManager에서 activeRelicsDict에서 int값 조정해주고 그 다음 체크
        foreach(var relic in RelicManager.Instance.activeRelicsDIct)
        {
            if(relic.Value == 1) // Relic value : 0 : 유물 효과 미적용, 1 : 효과 적용됨
            {
                RelicManager.Instance.activeRelicsDIct[relic.Key] = 0;
            }
        }
        //RelicManager.Instance.CheckRelics(this);
        

    }

    private void Update()
    {
        /*
        // Space 키로 코스트 증가 테스트
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Cur_Cost += 1;
            //Debug.Log($"Current Cost: {CurrentCost}");
            RelicManager.Instance.CheckRelics(this);
        }

        // H 키로 체력 감소 테스트
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerHealth -= 10;
            Debug.Log($"Player Health: {PlayerHealth}");
            RelicManager.Instance.CheckRelics(this);
        }
        */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            RelicManager.Instance.AddRelic("Old Helmet");
            P_Health = Player.GetComponent<PlayerStatus>().playerHP;
            Debug.Log($"P_HP: {P_Health}");
            RelicManager.Instance.CheckRelics(this);
            Debug.Log($"P_HP!!!: {P_Health}");

        }
    }
}
