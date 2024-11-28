using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        MapManager.Instance.ReturnToMap();
    }

    private void OnEnable()
    {
        UpdateNodeAccessibility();
    }

    private void UpdateNodeAccessibility()
    {
        Node currentNode = MapManager.Instance.currentNode;
        if (currentNode == null) return;

        // 현재 노드의 자식 노드 활성화
        if (currentNode.children != null)
        {
            foreach (var child in currentNode.children)
            {
                child.isAccessible = true;
            }
        }
    }
}
