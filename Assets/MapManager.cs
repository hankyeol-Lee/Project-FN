using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;
    public GameObject[] nodePrefab; // Node 프리팹
    public Transform mapParent; // Node를 배치할 부모 오브젝트
    public List<List<Node>> layers = new List<List<Node>>(); // Layer별 노드 리스트
    public Node currentNode; // 현재 선택된 노드
    public string mapSceneName = "MapScene"; // 맵 씬 이름

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
        layers.Clear(); // 기존 레이어 초기화

        int totalDepth = 7; // 레이어 개수

        for (int depth = 0; depth < totalDepth; depth++)
        {
            List<Node> layer = new List<Node>();

            // 노드 개수 결정
            int nodeCount = depth switch
            {
                0 => 1,        // 첫 번째 레이어: Start 노드 1개
                _ when depth == totalDepth - 1 => 1, // 마지막 레이어: Boss 노드 1개
                1 => 3,        // 두 번째 레이어: 노드 3개 고정
                _ => Random.Range(2, 4) // 중간 레이어: 노드 2~3개
            };

            for (int i = 0; i < nodeCount; i++)
            {
                GameObject prefab;

                // 첫 번째 노드는 Start 타입
                if (depth == 0)
                {
                    prefab = nodePrefab[0]; // Start 프리팹 (0번 인덱스)
                }
                // 마지막 레이어는 Boss 타입
                else if (depth == totalDepth - 1)
                {
                    prefab = nodePrefab[nodePrefab.Length - 1]; // Boss 프리팹 (항상 마지막 인덱스)
                }
                // 나머지는 랜덤 타입
                else
                {
                    int randomnum = Random.Range(1, nodePrefab.Length - 1); // Start, Boss 제외 랜덤
                    prefab = nodePrefab[randomnum];
                }

                Node node = Instantiate(prefab, mapParent).GetComponent<Node>();
                node.id = depth * 10 + i; // 고유 ID 설정
                node.transform.position = new Vector3(depth * 3.0f, -i * 2.5f, 0); // X축: 레이어, Y축: 노드 간 간격
                layer.Add(node);
            }

            layers.Add(layer);

            // 모든 노드 연결
            if (depth > 0)
            {
                ConnectLayers(layers[depth - 1], layers[depth]);
            }

            // 레이어 정보 출력
            Debug.Log($"Layer {depth} - Nodes: {string.Join(", ", layer)}");
        }

        // 첫 노드 활성화
        layers[0][0].isAccessible = true;
        Debug.Log("첫노드활성화");

        // 연결 시각화
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
        // Z축 고정
        start.z = 0;
        end.z = 0;

        GameObject line = new GameObject("Line");
        line.transform.SetParent(mapParent, false);

        LineRenderer lr = line.AddComponent<LineRenderer>();

        // LineRenderer 설정
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        // Material 설정
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.white;
        lr.endColor = Color.white;

        // 정렬 우선순위
        lr.sortingOrder = 1;

        // Debugging용 로그 출력
        Debug.Log($"Line drawn from {start} to {end}");
    }

    public void LoadSceneForNode(Node node)
    {
        currentNode = node;
        Debug.Log("다음씬으로이동!");
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
        // 각 부모 노드를 랜덤하게 자식 노드와 연결
        foreach (var parent in parentLayer)
        {
            int childCount = Random.Range(1, childLayer.Count + 1); // 자식 노드 수 결정 (1개 이상)
            for (int i = 0; i < childCount; i++)
            {
                Node child = childLayer[Random.Range(0, childLayer.Count)];
                parent.children = parent.children == null ? new Node[1] : AddToArray(parent.children, child);

                // 자식 노드의 부모 설정
                child.parent = parent;
            }
        }

        // 각 자식 노드가 적어도 하나의 부모 노드와 연결되도록 보장
        foreach (var child in childLayer)
        {
            if (child.parent == null) // 부모가 없는 자식만 처리
            {
                Node parent = parentLayer[Random.Range(0, parentLayer.Count)];
                parent.children = parent.children == null ? new Node[1] : AddToArray(parent.children, child);

                // 자식 노드의 부모 설정
                child.parent = parent;
            }
        }
    }


}
