using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;
    public GameObject[] nodePrefab; // Node ������
    public Transform mapParent; // Node�� ��ġ�� �θ� ������Ʈ
    public List<List<Node>> layers = new List<List<Node>>(); // Layer�� ��� ����Ʈ
    public static Node currentNode; // ���� ���õ� ���
    public string mapSceneName = "MapScene"; // �� �� �̸�
    private bool isMapGenerated = false; // �� ���� ���� �÷���

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� MapManager ����

            GameObject nodeContainer = new GameObject("NodeContainer");
            DontDestroyOnLoad(nodeContainer);
            mapParent = nodeContainer.transform;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (!isMapGenerated)
        {
            GenerateMap(); // ���� �� ���� �������� �ʾ����� ����
            isMapGenerated = true;
        }
        else
        {
            Debug.Log("���� �̹� ������. �ٽ� �������� ����.");
        }
    }

    public void GenerateMap()
    {
        layers.Clear(); // ���� ���̾� �ʱ�ȭ

        int totalDepth = 6; // ���̾� ����
        Vector3 startPosition = transform.position; // ù ��° ����� ��ġ�� NodeMapManager ��ġ�� ����

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

                // ù ��° ���� NodeMapManager ��ġ�� ��ġ
                if (depth == 0)
                {
                    node.transform.position = startPosition;
                    currentNode = node;
                }
                else
                {
                    // ���� ���̾� ��� ��ġ�� X�� �������� �������� �̵�, Y���� ���� ����
                    float xOffset = depth * 3.0f; // ���̾ X�� �̵� ����
                    float yOffset = (i - (nodeCount - 1) / 2.0f) * -2.5f; // Y�� �߾� ����
                    node.transform.position = new Vector3(startPosition.x + xOffset, startPosition.y + yOffset, 0);
                }

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

        // LineRenderer �⺻ ����
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.positionCount = 2;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = new Color(0.7019607843137254f, 0.5725490196078431f, 0.5137254901960784f, 1.0f);
        lr.endColor = new Color(0.7019607843137254f, 0.5725490196078431f, 0.5137254901960784f, 1.0f);
         
        // �ʱ� �������� ����
        lr.SetPosition(0, start);
        lr.SetPosition(1, start); // ó���� ���������� ���� ����

        // Dotween���� ������ �ִϸ��̼�
        DOTween.To(
            () => start,               // ������
            value => lr.SetPosition(1, value), // ���� ������Ʈ
            end,                       // ��ǥ ��ġ
            1.0f                       // �ִϸ��̼� ���� �ð�
        ).SetEase(Ease.OutQuad); // Ease ���� (�ε巯�� �ִϸ��̼�)
    }

    public void LoadSceneForNode(Node node)
    {
        currentNode = node;
        if (currentNode != null)
        {
            SpriteRenderer sr = currentNode.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = Color.red; // currentNode�� ����������
            }
        }

        Debug.Log("�����������̵�!");
        HideNodeContainer();

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
    //������ �����ϴ°�
    public void HideNodeContainer()
    {
        if (mapParent != null)
        {
            mapParent.gameObject.SetActive(false);
            Debug.Log("Node �����̳ʰ� ��Ȱ��ȭ�Ǿ����ϴ�.");
        }
    }

    public void ShowNodeContainer()
    {
        if (mapParent != null)
        {
            mapParent.gameObject.SetActive(true);
            Debug.Log("Node �����̳ʰ� Ȱ��ȭ�Ǿ����ϴ�.");
        }
    }
    public void UpdateNodeAccessibility()
    {
        if (currentNode == null)
        {
            Debug.LogWarning("currentNode�� �������� �ʾҽ��ϴ�. �ʱ� ��带 Ȱ��ȭ�մϴ�.");
            if (layers.Count > 0 && layers[0].Count > 0)
            {
                layers[0][0].isAccessible = true; // ù ��� Ȱ��ȭ
            }
            return;
        }

        // 1. ���� ��� ��Ȱ��ȭ
        currentNode.isAccessible = false;

        // 2. ���� ����� �θ� ��� Ȯ��
        if (currentNode.parent != null)
        {
            var parentNode = currentNode.parent;

            // �θ� ����� ��� �ڽ� ��带 ��Ȱ��ȭ
            foreach (var sibling in parentNode.children)
            {
                sibling.isAccessible = false;
                Debug.Log($"���� ��� {sibling.id} ��Ȱ��ȭ��.");
            }
        }

        // 3. ���� ����� �ڽ� ��� Ȱ��ȭ
        if (currentNode.children != null && currentNode.children.Length > 0)
        {
            foreach (var child in currentNode.children)
            {
                child.isAccessible = true;
                Debug.Log($"�ڽ� ��� {child.id} Ȱ��ȭ��.");
            }
        }
        else
        {
            Debug.LogWarning($"���� ��� {currentNode.id}�� �ڽ� ��尡 �����ϴ�.");
        }
    }



}
