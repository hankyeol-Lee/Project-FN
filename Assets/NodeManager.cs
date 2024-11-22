using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] private NodeData startNodeData;  // ���� ���� �� ����� ���
    private NodeData currentNode;  // ���� ���

    void Start()
    {
        // ���� ��带 �ʱ�ȭ
        currentNode = startNodeData;

        // UI ����
        FindObjectOfType<NodeUIManager>().DisplayAdjacentNodes(currentNode);
    }

    public void MoveToNode(NodeData nextNode)
    {
        if (currentNode.adjacentNodes.Contains(nextNode))
        {
            currentNode = nextNode;
            Debug.Log("���� ���� �̵�: " + currentNode.nodeName);

            // UI ����
            FindObjectOfType<NodeUIManager>().DisplayAdjacentNodes(currentNode);
        }
        else
        {
            Debug.LogError("�̵��� �� ���� ����Դϴ�.");
        }
    }
}
