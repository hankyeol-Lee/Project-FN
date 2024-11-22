using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] private NodeData startNodeData;  // 게임 시작 시 사용할 노드
    private NodeData currentNode;  // 현재 노드

    void Start()
    {
        // 시작 노드를 초기화
        currentNode = startNodeData;

        // UI 갱신
        FindObjectOfType<NodeUIManager>().DisplayAdjacentNodes(currentNode);
    }

    public void MoveToNode(NodeData nextNode)
    {
        if (currentNode.adjacentNodes.Contains(nextNode))
        {
            currentNode = nextNode;
            Debug.Log("다음 노드로 이동: " + currentNode.nodeName);

            // UI 갱신
            FindObjectOfType<NodeUIManager>().DisplayAdjacentNodes(currentNode);
        }
        else
        {
            Debug.LogError("이동할 수 없는 노드입니다.");
        }
    }
}
