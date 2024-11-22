using UnityEngine;
using UnityEngine.UI;

public class NodeButton : MonoBehaviour
{
    private NodeData linkedNode;

    public void Initialize(NodeData node)
    {
        linkedNode = node;
        GetComponentInChildren<Text>().text = node.nodeName;  // ��ư�� ��� �̸� ǥ��
        GetComponent<Button>().onClick.AddListener(OnNodeSelected);
    }

    private void OnNodeSelected()
    {
        FindObjectOfType<NodeManager>().MoveToNode(linkedNode);
    }
}
