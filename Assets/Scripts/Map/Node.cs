using UnityEngine;


 public enum NodeType { Start,Normal, Elite, Boss, Encounter }

public class Node : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public NodeType nodeType;
    public int id; // 각 Node의 고유 ID
    public Node[] children; // 다음 레이어 노드들
    public Node parent;
    public bool isAccessible = false; // 접근 가능 여부

    private void OnMouseDown()
    {
        if (!isAccessible) return;

        // Node 선택 시 해당 Scene 로드
        MapManager.Instance.LoadSceneForNode(this);
    }
}
