using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public static bool isFirstLoad = true; //�ѹ���üũ..�ε� �̰� �����̾���


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
            MapManager.Instance.UpdateNodeAccessibility(); // ��� ���ټ� ������Ʈ

        }
        Debug.Log("������ : "+MapManager.currentNode);

    }
}
