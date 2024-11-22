using System.Collections.Generic;
using UnityEngine;

public class NodeUIManager : MonoBehaviour
{
    public GameObject buttonPrefab;  // ��ư ������
    public Transform buttonParent;  // ��ư�� ��ġ�� �θ� ������Ʈ

    private List<GameObject> currentButtons = new List<GameObject>();

    public void DisplayAdjacentNodes(NodeData currentNode)
    {
        // ���� ��ư ����
        foreach (var button in currentButtons)
        {
            Destroy(button);
        }
        currentButtons.Clear();

        // ���� ��忡 ���� ��ư ����
        foreach (var node in currentNode.adjacentNodes)
        {
            GameObject button = Instantiate(buttonPrefab, buttonParent);
            NodeButton nodeButton = button.GetComponent<NodeButton>();
            nodeButton.Initialize(node);
            currentButtons.Add(button);
        }
    }
}
