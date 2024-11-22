using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static TreeEditor.TreeEditorHelper;

public class NodeManager : MonoBehaviour
{
    public List<GameObject> Nodes = new List<GameObject>(5); // Node ����Ʈ
    public GameObject nodePointer; // ���� ���õ� ���
    public static NodeManager instance; // �̱��� �ν��Ͻ�

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject); // ��� �Ŵ����� �� ��ȯ �� �ı����� �ʰ� ����
    }

    private void Start()
    {
        if (Nodes.Count > 0)
        {
            nodePointer = Nodes[0]; // �ʱ� ��� ����
            Debug.Log(nodePointer.name);
            HighlightNode(nodePointer, true); // �ʱ� ��� ����
        }
    }

    public void OnNodeClick()
    {
        if (nodePointer != null)
        {
            Debug.Log("�� ���̾�");
            // Ÿ�� Ȯ�� �� �� �ε�
            NodeType nodeType = nodePointer.GetComponent<NodeType>();
            Debug.Log(nodeType);
            if (nodeType != null)
            {
                LoadSceneByType(nodeType.type);
            }

            // ���� ����� ���� ����
            HighlightNode(nodePointer, false);

            // ���� ���� �̵�
            int currentIndex = Nodes.IndexOf(nodePointer);
            int nextIndex = (currentIndex + 1) % Nodes.Count; // ��ȯ ����
            nodePointer = Nodes[nextIndex];

            // ���ο� ��� ����
            HighlightNode(nodePointer, true);
        }
    }

    private void HighlightNode(GameObject node, bool isHighlighted)
    {
        // UI ������ ����
        Image nodeImage = node.GetComponent<Image>();
        if (nodeImage != null)
        {
            Color color = nodeImage.color;
            color.a = isHighlighted ? 1f : 0.5f; // ������ ���� ������, ���� ������ ������
            nodeImage.color = color;
        }
    }

    private void LoadSceneByType(string type)
    {
        switch (type)
        {
            case "Battle":
                SceneManager.LoadScene("GamePlayScene"); // "BattleScene"�� �ҷ���
                break;
            case "Elite":
                SceneManager.LoadScene("GamePlayScene"); // "EliteScene"�� �ҷ���
                break;
            default:
                Debug.LogWarning("Unknown node type: " + type);
                break;
        }
    }
}
