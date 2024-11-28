using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public static bool isFirstLoad = true; //한번만체크..인데 이거 개어이없네


    private void Start()
    {
        //UpdateNodeAccessibility();
        
        MapManager.Instance.ShowNodeContainer();
        if (isFirstLoad )
        {
            isFirstLoad = false;
        }
        else
        {
            MapManager.Instance.UpdateNodeAccessibility(); // 노드 접근성 업데이트

        }
        Debug.Log("현재노드 : "+MapManager.currentNode);

    }
}
