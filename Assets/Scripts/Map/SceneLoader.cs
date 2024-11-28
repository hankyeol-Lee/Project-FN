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

        // ���� ����� �ڽ� ��� Ȱ��ȭ
        if (currentNode.children != null)
        {
            foreach (var child in currentNode.children)
            {
                child.isAccessible = true;
            }
        }
    }
}
