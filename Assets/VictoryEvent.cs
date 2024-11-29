using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryEvent : MonoBehaviour
{
    public void OnClickHealButton()
    {
        float playerHP = GameManager.Instance.player.GetComponent<PlayerStatus>().playerHP;
        playerHP = playerHP + playerHP * 0.15f;
        Destroy(gameObject);
    }
    public void GoToNextMap()
    {
        SceneManager.LoadScene("MapScene");
    }
}
