using System.Collections.Generic;
using UnityEngine;

namespace HexClass // pathfinding 메소드는 다른 객체에서도 사용 가능하도록, namespace로 저장.
{
    public class Hex
    {
        public int q, r;

        public Hex(int q, int r)
        {
            this.q = q;
            this.r = r;
            
        }

        public Hex(Vector3Int vec)
        {
            this.q = vec.x;
            this.r = vec.y;
            
        }

        public Vector3Int ToVector3Int()
        {
            return new Vector3Int(q, r);
        }

        public override bool Equals(object obj)
        {
            if (obj is Hex other)
            {
                return q == other.q && r == other.r;
            }
            return false;
        }

        public override int GetHashCode()
        {
            // Hash code 개선
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + q.GetHashCode();
                hash = hash * 31 + r.GetHashCode();
                
                return hash;
            }
        }

        public List<Hex> GetNeighbors(Hex goal) // 주변 Hex
        {
            List<Hex> neighbors = new List<Hex>
            {
                new Hex(q + 1, r), //위
                new Hex(q - 1, r), // 아래
                new Hex(q, r + 1), // 오른쪽 위
                new Hex(q, r - 1), // 왼쪽 위
                new Hex(q + 1, r - 1), // 왼쪽 아래
                new Hex(q - 1, r + 1) // 오른쪽 아래
            };
            neighbors.Sort((a, b) =>
            {
                int aDist = Hex.Distance(a, goal);
                int bDist = Hex.Distance(b, goal);
                return aDist.CompareTo(bDist); // 목표에 더 가까운 방향을 우선
            });


            return neighbors;
        }

        public static int Distance(Hex a, Hex b)
        {
            return Mathf.Max(Mathf.Abs(a.q - b.q), Mathf.Abs(a.r - b.r), Mathf.Abs((-a.q - a.r) - (-b.q - b.r))); //맨해튼 거리 말고 큐브 거리로 계산.
        }

        public static int Heuristic(Hex a, Hex b)
        {
            return Distance(a, b);
        }
    }

    public class HexPathfinding // A* 알고리즘
    {
        public static List<Vector3Int> FindPath(Vector3Int playerPosition, Vector3Int mousePosition, HashSet<Hex> obstacles)
        {
            Hex start = new Hex(playerPosition); // 플레이어 위치에 있는 hex를 start라고 저장
            Hex goal = new Hex(mousePosition); // 마우스로 찍은, 목표 지점을 goal이라는 hex로 저장

            Dictionary<Hex, Hex> cameFrom = new Dictionary<Hex, Hex>(); // 현재 hex와 그 전 hex를 저장하는 딕셔너리
            Dictionary<Hex, int> costSoFar = new Dictionary<Hex, int>(); // 몇 칸이 걸리는지 저장하는 딕셔너리

            PriorityQueue<Hex> frontier = new PriorityQueue<Hex>(); // frontier라는 우선순위 큐 생성.
            frontier.Enqueue(start, 0); // 큐의 첫번째 원소로 start를 넣음.

            cameFrom[start] = null;
            costSoFar[start] = 0;

            while (frontier.Count > 0)
            {
                Hex current = frontier.Dequeue(); // 현재 hex, 즉 노드는 큐의 제일 첫번재 값. 첫번째 시행은 현재 위치를 가리킴.

                if (current.Equals(goal)) // 만약 현재와 goal이 똑같을 경우, 위치에 도달했으므로 종료.
                    break;

                List<Hex> neighbors = current.GetNeighbors(goal);
                foreach (Hex next in neighbors) // 이웃한 노드를 조사.
                {
                    // 장애물 검사
                    if (obstacles.Contains(next)) // 장애물이면 무시
                        continue;

                    int newCost = costSoFar[current] + 1; 
                    if (!costSoFar.TryGetValue(next, out int existingCost) || newCost <= existingCost) // 노드를 처음 방문하거나 또는 기존 경로의 비용보다 더 작을 경우
                    {
                        costSoFar[next] = newCost; // 얼마나 걸리는지 업데이트.
                        int priority = newCost + Hex.Heuristic(next, goal); // 우선순위 설정. 휴리스틱 함수를 이용해 다음칸과 목표까지 얼마나 걸리는지 체크
                        frontier.Enqueue(next, priority); // 우선순위 큐에 넣음.
                        cameFrom[next] = current; // 어디서 왔는지를 저장함.
                    }
                }
            }

            List<Vector3Int> path = new List<Vector3Int>(); // 이동경로를 저장할 path 리스트 생성.
            Hex temp = goal;

            while (temp != null)
            {
                if (!cameFrom.TryGetValue(temp, out Hex prev))
                {
                    Debug.LogError($"Pathfinding error: No path from {temp.q},{temp.r}");
                    break;
                }
                path.Add(temp.ToVector3Int());
                temp = prev;
            }

            path.Reverse();
            return path;
        }

    }


    public class PriorityQueue<T> //우선순위 큐 클래스. 선입후출의 구조를 가지고 있지만, Enqueue할때 따로 sort하게 됨.
    {
        private List<KeyValuePair<T, int>> elements = new List<KeyValuePair<T, int>>();

        public int Count => elements.Count;

        public void Enqueue(T item, int priority)
        {
            elements.Add(new KeyValuePair<T, int>(item, priority));
            elements.Sort((x, y) => x.Value.CompareTo(y.Value));
        }

        public T Dequeue()
        {
            var bestItem = elements[0].Key;
            elements.RemoveAt(0);
            return bestItem;
        }
    }
}
