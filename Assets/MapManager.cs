using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;
    public GameObject[] nodePrefab; // Node ������
    public Transform mapParent; // Node�� ��ġ�� �θ� ������Ʈ
    public List<List<Node>> layers = new List<List<Node>>(); // Layer�� ��� ����Ʈ
    public Node currentNode; // ���� ���õ� ���
    public string mapSceneName = "MapScene"; // �� �� �̸�

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        layers.Clear(); // ���� ���̾� �ʱ�ȭ

        int totalDepth = 7; // ���̾� ����

        for (int depth = 0; depth < totalDepth; depth++)
        {
            List<Node> layer = new List<Node>();

            // ��� ���� ����
            int nodeCount = depth switch
            {
                0 => 1,        // ù ��° ���̾�: Start ��� 1��
                _ when depth == totalDepth - 1 => 1, // ������ ���̾�: Boss ��� 1��
                1 => 3,        // �� ��° ���̾�: ��� 3�� ����
                _ => Random.Range(2, 4) // �߰� ���̾�: ��� 2~3��
            };

            for (int i = 0; i < nodeCount; i++)
            {
                GameObject prefab;

                // ù ��° ���� Start Ÿ��
                if (depth == 0)
                {
                    prefab = nodePrefab[0]; // Start ������ (0�� �ε���)
                }
                // ������ ���̾�� Boss Ÿ��
                else if (depth == totalDepth - 1)
                {
                    prefab = nodePrefab[nodePrefab.Length - 1]; // Boss ������ (�׻� ������ �ε���)
                }
                // �������� ���� Ÿ��
                else
                {
                    int randomnum = Random.Range(1, nodePrefab.Length - 1); // Start, Boss ���� ����
                    prefab = nodePrefab[randomnum];
                }

                Node node = Instantiate(prefab, mapParent).GetComponent<Node>();
                node.id = depth * 10 + i; // ���� ID ����
                node.transform.position = new Vector3(depth * 3.0f, -i * 2.5f, 0); // X��: ���̾�, Y��: ��� �� ����
                layer.Add(node);
            }

            layers.Add(layer);

            // ��� ��� ����
            if (depth > 0)
            {
                ConnectLayers(layers[depth - 1], layers[depth]);
            }

            // ���̾� ���� ���
            Debug.Log($"Layer {depth} - Nodes: {string.Join(", ", layer)}");
        }

        // ù ��� Ȱ��ȭ
        layers[0][0].isAccessible = true;
        Debug.Log("ù���Ȱ��ȭ");

        // ���� �ð�ȭ
        DrawConnections();
    }


    private T[] AddToArray<T>(T[] original, T item)
    {
        List<T> list = new List<T>(original) { item };
        return list.ToArray();
    }

    public void DrawConnections()
    {
        foreach (var layer in layers)
        {
            foreach (var node in layer)
            {
                if (node.children == null) continue;

                foreach (var child in node.children)
                {
                    Debug.Log(child);
                    DrawLine(node.transform.position, child.transform.position);
                }
            }
        }
    }

    private void DrawLine(Vector3 start, Vector3 end)
    {
        // Z�� ����
        start.z = 0;
        end.z = 0;

        GameObject line = new GameObject("Line");
        line.transform.SetParent(mapParent, false);

        LineRenderer lr = line.AddComponent<LineRenderer>();

        // LineRenderer ����
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        // Material ����
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.white;
        lr.endColor = Color.white;

        // ���� �켱����
        lr.sortingOrder = 1;

        // Debugging�� �α� ���
        Debug.Log($"Line drawn from {start} to {end}");
    }

    public void LoadSceneForNode(Node node)
    {
        currentNode = node;
        Debug.Log("�����������̵�!");
        if (node.nodeType == NodeType.Normal)
        {
            SceneManager.LoadScene("GamePlayScene");

        }
        else if (node.nodeType == NodeType.Encounter)
        {
            SceneManager.LoadScene("GamePlayScene");
        }
        //SceneManager.LoadScene(node.nodeType.ToString() + "Scene");
    }

    public void ReturnToMap()
    {
        SceneManager.LoadScene(mapSceneName);
    }
    private void ConnectLayers(List<Node> parentLayer, List<Node> childLayer)
    {
        // �� �θ� ��带 �����ϰ� �ڽ� ���� ����
        foreach (var parent in parentLayer)
        {
            int childCount = Random.Range(1, childLayer.Count + 1); // �ڽ� ��� �� ���� (1�� �̻�)
            for (int i = 0; i < childCount; i++)
            {
                Node child = childLayer[Random.Range(0, childLayer.Count)];
                parent.children = parent.children == null ? new Node[1] : AddToArray(parent.children, child);

                // �ڽ� ����� �θ� ����
                child.parent = parent;
            }
        }

        // �� �ڽ� ��尡 ��� �ϳ��� �θ� ���� ����ǵ��� ����
        foreach (var child in childLayer)
        {
            if (child.parent == null) // �θ� ���� �ڽĸ� ó��
            {
                Node parent = parentLayer[Random.Range(0, parentLayer.Count)];
                parent.children = parent.children == null ? new Node[1] : AddToArray(parent.children, child);

                // �ڽ� ����� �θ� ����
                child.parent = parent;
            }
        }
    }


}
