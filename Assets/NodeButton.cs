using UnityEngine;
using UnityEngine.UI;

public class NodeButton : MonoBehaviour
{
    private NodeData linkedNode;

    public void Initialize(NodeData node)
    {
        linkedNode = node;
        GetComponentInChildren<Text>().text = node.nodeName;  // 버튼에 노드 이름 표시
        GetComponent<Button>().onClick.AddListener(OnNodeSelected);
    }

    private void OnNodeSelected()
    {
        FindObjectOfType<NodeManager>().MoveToNode(linkedNode);
    }
}
