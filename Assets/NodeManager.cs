using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static TreeEditor.TreeEditorHelper;

public class NodeManager : MonoBehaviour
{
    public List<GameObject> Nodes = new List<GameObject>(5); // Node 리스트
    public GameObject nodePointer; // 현재 선택된 노드
    public static NodeManager instance; // 싱글톤 인스턴스

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject); // 노드 매니저가 씬 전환 시 파괴되지 않게 설정
    }

    private void Start()
    {
        if (Nodes.Count > 0)
        {
            nodePointer = Nodes[0]; // 초기 노드 설정
            Debug.Log(nodePointer.name);
            HighlightNode(nodePointer, true); // 초기 노드 강조
        }
    }

    public void OnNodeClick()
    {
        if (nodePointer != null)
        {
            Debug.Log("어 형이야");
            // 타입 확인 및 씬 로드
            NodeType nodeType = nodePointer.GetComponent<NodeType>();
            Debug.Log(nodeType);
            if (nodeType != null)
            {
                LoadSceneByType(nodeType.type);
            }

            // 이전 노드의 강조 해제
            HighlightNode(nodePointer, false);

            // 다음 노드로 이동
            int currentIndex = Nodes.IndexOf(nodePointer);
            int nextIndex = (currentIndex + 1) % Nodes.Count; // 순환 구조
            nodePointer = Nodes[nextIndex];

            // 새로운 노드 강조
            HighlightNode(nodePointer, true);
        }
    }

    private void HighlightNode(GameObject node, bool isHighlighted)
    {
        // UI 투명도를 조정
        Image nodeImage = node.GetComponent<Image>();
        if (nodeImage != null)
        {
            Color color = nodeImage.color;
            color.a = isHighlighted ? 1f : 0.5f; // 강조된 노드는 불투명, 강조 해제는 반투명
            nodeImage.color = color;
        }
    }

    private void LoadSceneByType(string type)
    {
        switch (type)
        {
            case "Battle":
                SceneManager.LoadScene("GamePlayScene"); // "BattleScene"을 불러옴
                break;
            case "Elite":
                SceneManager.LoadScene("GamePlayScene"); // "EliteScene"을 불러옴
                break;
            default:
                Debug.LogWarning("Unknown node type: " + type);
                break;
        }
    }
}
