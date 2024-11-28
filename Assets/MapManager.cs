using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;
    public GameObject[] nodePrefab; // Node 프리팹
    public Transform mapParent; // Node를 배치할 부모 오브젝트
    public List<List<Node>> layers = new List<List<Node>>(); // Layer별 노드 리스트
    public static Node currentNode; // 현재 선택된 노드
    public string mapSceneName = "MapScene"; // 맵 씬 이름
    private bool isMapGenerated = false; // 맵 생성 여부 플래그

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 MapManager 유지

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
            GenerateMap(); // 맵이 한 번도 생성되지 않았으면 생성
            isMapGenerated = true;
        }
        else
        {
            Debug.Log("맵이 이미 생성됨. 다시 생성하지 않음.");
        }
    }

    public void GenerateMap()
    {
        layers.Clear(); // 기존 레이어 초기화

        int totalDepth = 6; // 레이어 개수
        Vector3 startPosition = transform.position; // 첫 번째 노드의 위치를 NodeMapManager 위치로 설정

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

                // 첫 번째 노드는 NodeMapManager 위치에 배치
                if (depth == 0)
                {
                    node.transform.position = startPosition;
                    currentNode = node;
                }
                else
                {
                    // 다음 레이어 노드 위치는 X축 기준으로 우측으로 이동, Y축은 간격 유지
                    float xOffset = depth * 3.0f; // 레이어별 X축 이동 간격
                    float yOffset = (i - (nodeCount - 1) / 2.0f) * -2.5f; // Y축 중앙 정렬
                    node.transform.position = new Vector3(startPosition.x + xOffset, startPosition.y + yOffset, 0);
                }

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

        // LineRenderer 기본 설정
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.positionCount = 2;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = new Color(0.7019607843137254f, 0.5725490196078431f, 0.5137254901960784f, 1.0f);
        lr.endColor = new Color(0.7019607843137254f, 0.5725490196078431f, 0.5137254901960784f, 1.0f);
         
        // 초기 시작점만 설정
        lr.SetPosition(0, start);
        lr.SetPosition(1, start); // 처음엔 시작점으로 끝점 지정

        // Dotween으로 끝점을 애니메이션
        DOTween.To(
            () => start,               // 시작점
            value => lr.SetPosition(1, value), // 끝점 업데이트
            end,                       // 목표 위치
            1.0f                       // 애니메이션 지속 시간
        ).SetEase(Ease.OutQuad); // Ease 설정 (부드러운 애니메이션)
    }

    public void LoadSceneForNode(Node node)
    {
        currentNode = node;
        if (currentNode != null)
        {
            SpriteRenderer sr = currentNode.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = Color.red; // currentNode를 빨간색으로
            }
        }

        Debug.Log("다음씬으로이동!");
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
    //씬에서 관리하는거
    public void HideNodeContainer()
    {
        if (mapParent != null)
        {
            mapParent.gameObject.SetActive(false);
            Debug.Log("Node 컨테이너가 비활성화되었습니다.");
        }
    }

    public void ShowNodeContainer()
    {
        if (mapParent != null)
        {
            mapParent.gameObject.SetActive(true);
            Debug.Log("Node 컨테이너가 활성화되었습니다.");
        }
    }
    public void UpdateNodeAccessibility()
    {
        if (currentNode == null)
        {
            Debug.LogWarning("currentNode가 설정되지 않았습니다. 초기 노드를 활성화합니다.");
            if (layers.Count > 0 && layers[0].Count > 0)
            {
                layers[0][0].isAccessible = true; // 첫 노드 활성화
            }
            return;
        }

        // 1. 현재 노드 비활성화
        currentNode.isAccessible = false;

        // 2. 현재 노드의 부모 노드 확인
        if (currentNode.parent != null)
        {
            var parentNode = currentNode.parent;

            // 부모 노드의 모든 자식 노드를 비활성화
            foreach (var sibling in parentNode.children)
            {
                sibling.isAccessible = false;
                Debug.Log($"형제 노드 {sibling.id} 비활성화됨.");
            }
        }

        // 3. 현재 노드의 자식 노드 활성화
        if (currentNode.children != null && currentNode.children.Length > 0)
        {
            foreach (var child in currentNode.children)
            {
                child.isAccessible = true;
                Debug.Log($"자식 노드 {child.id} 활성화됨.");
            }
        }
        else
        {
            Debug.LogWarning($"현재 노드 {currentNode.id}에 자식 노드가 없습니다.");
        }
    }



}
