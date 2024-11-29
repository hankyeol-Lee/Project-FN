using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("sceneChange");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator sceneChange(){
        float playerHPS = PlayerStatus.Instance.playerHP;
        PlayerStatus.Instance.playerHP += playerHPS * 0.15f;
        //체력회복
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MapScene");
    }
}
