using UnityEngine;


 public enum NodeType { Start,Normal, Elite, Boss, Encounter }

public class Node : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public NodeType nodeType;
    public int id; // �� Node�� ���� ID
    public Node[] children; // ���� ���̾� ����
    public Node parent;
    public bool isAccessible = false; // ���� ���� ����

    private void OnMouseDown()
    {
        if (!isAccessible) return;

        // Node ���� �� �ش� Scene �ε�
        MapManager.Instance.LoadSceneForNode(this);
    }
}
