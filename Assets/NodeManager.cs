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
            PlayerPrefs.Save();
        }
    }

    private void RestoreNodeState()
    {
        string savedNodeName = PlayerPrefs.GetString("CurrentNodeName", string.Empty);

        if (!string.IsNullOrEmpty(savedNodeName))
        {
            Nodes.Clear();
            Nodes.AddRange(GameObject.FindGameObjectsWithTag("Node"));

            GameObject savedNode = Nodes.Find(node => node.name == savedNodeName);
            if (savedNode != null)
            {
                nodePointer = savedNode;
                HighlightNode(nodePointer, true);
            }
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
