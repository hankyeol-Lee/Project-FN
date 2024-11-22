using System.Collections.Generic;
using UnityEngine;

public class NodeUIManager : MonoBehaviour
{
    public GameObject buttonPrefab;  // 버튼 프리팹
    public Transform buttonParent;  // 버튼을 배치할 부모 오브젝트

    private List<GameObject> currentButtons = new List<GameObject>();

    public void DisplayAdjacentNodes(NodeData currentNode)
    {
        // 기존 버튼 삭제
        foreach (var button in currentButtons)
        {
            Destroy(button);
        }
        currentButtons.Clear();

        // 인접 노드에 대해 버튼 생성
        foreach (var node in currentNode.adjacentNodes)
        {
            GameObject button = Instantiate(buttonPrefab, buttonParent);
            NodeButton nodeButton = button.GetComponent<NodeButton>();
            nodeButton.Initialize(node);
            currentButtons.Add(button);
        }
    }
}
