using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatSceneChange : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine("sceneChange");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator sceneChange(){
        yield return new WaitForSeconds(3f);
        Application.Quit();
    }
}
