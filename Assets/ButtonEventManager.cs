using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEventManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnstartbuttonClick(){
        SceneManager.LoadScene("MapScene");
    }

    public void GameExit()
{
        Application.Quit();
}
}
