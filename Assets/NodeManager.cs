using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NodeManager : MonoBehaviour
{
    public List<GameObject> Nodes = new List<GameObject>();
    public GameObject nodePointer;
    public static NodeManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (Nodes.Count > 0)
        {
            nodePointer = Nodes[0];
            HighlightNode(nodePointer, true);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnNodeClick()
    {
        if (nodePointer != null)
        {
            NodeType nodeType = nodePointer.GetComponent<NodeType>();
            if (nodeType != null)
            {
                LoadSceneByType(nodeType.type);
            }

            // ���� ��� ���� ����
            HighlightNode(nodePointer, false);

            // ���� ���� �̵�
            int currentIndex = Nodes.IndexOf(nodePointer);
            int nextIndex = (currentIndex + 1) % Nodes.Count; // ��ȯ �̵�
            nodePointer = Nodes[nextIndex];

            // ���ο� ��� ����
            HighlightNode(nodePointer, true);

            // ����� ���� ����
            SaveNodeState();
        }
    }


    private void HighlightNode(GameObject node, bool isHighlighted)
    {
        Image nodeImage = node.GetComponent<Image>();
        if (nodeImage != null)
        {
            Color color = nodeImage.color;
            color.a = isHighlighted ? 1f : 0.5f;
            nodeImage.color = color;
        }
    }

    private void LoadSceneByType(string type)
    {
        SaveNodeState();

        switch (type)
        {
            case "Battle":
                SceneManager.LoadScene("GamePlayScene");
                break;
            case "Elite":
                SceneManager.LoadScene("GamePlayScene");
                break;
            default:
                Debug.LogWarning("Unknown node type: " + type);
                break;
        }
    }

    private void SaveNodeState()
    {
        if (nodePointer != null)
        {
            PlayerPrefs.SetString("CurrentNodeName", nodePointer.name);
            PlayerPrefs.SetInt("CurrentNodeIndex", Nodes.IndexOf(nodePointer)); // ���� ��� �ε��� ����
        }

        List<string> nodeNames = new List<string>();
        foreach (var node in Nodes)
        {
            if (node != null)
            {
                nodeNames.Add(node.name);
            }
        }

        PlayerPrefs.SetString("Nodes", string.Join(",", nodeNames));
        PlayerPrefs.Save();
    }


    private void RestoreNodeState()
    {
        string savedNodeName = PlayerPrefs.GetString("CurrentNodeName", string.Empty);
        int savedNodeIndex = PlayerPrefs.GetInt("CurrentNodeIndex", 0); // ����� �ε��� ����
        string savedNodes = PlayerPrefs.GetString("Nodes", string.Empty);

        if (!string.IsNullOrEmpty(savedNodes))
        {
            Nodes.Clear();
            string[] nodeNames = savedNodes.Split(',');

            foreach (string nodeName in nodeNames)
            {
                GameObject node = GameObject.Find(nodeName);
                if (node != null)
                {
                    Nodes.Add(node);
                }
            }
        }

        if (Nodes.Count > 0)
        {
            // ����� �ε����� �������� ����
            if (savedNodeIndex < Nodes.Count)
            {
                nodePointer = Nodes[savedNodeIndex];
            }
            else
            {
                // �ε����� ��ȿ���� ���� ��� ù ��° ���� ����
                nodePointer = Nodes[0];
            }

            HighlightNode(nodePointer, true);
        }
    }



    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SelectScene")
        {
            RestoreNodeState();
        }
        else
        {
            Nodes.Clear();
            Nodes.AddRange(GameObject.FindGameObjectsWithTag("Node"));

            if (Nodes.Count > 0)
            {
                nodePointer = Nodes[0];
                HighlightNode(nodePointer, true);
            }
        }
    }
}
