using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

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

        public List<Hex> GetNeighbors()
        {
            List<Hex> neighbors = new List<Hex>();

            bool oddRow = Mathf.Abs(r % 2) == 1;
            //Debug.Log($"Current Hex: ({q}, {r}), Odd Row: {oddRow}");

            if (oddRow)
            {
                // 홀수 행에 대한 이웃 노드 정의
                neighbors.Add(new Hex(q + 1, r)); // 오른쪽
                neighbors.Add(new Hex(q - 1, r)); // 왼쪽
                neighbors.Add(new Hex(q, r + 1)); // 위
                neighbors.Add(new Hex(q, r - 1)); // 아래
                neighbors.Add(new Hex(q + 1, r - 1)); // 오른쪽 아래
                neighbors.Add(new Hex(q + 1, r + 1)); // 오른쪽 위

                //Debug.Log($"Neighbors for Odd Row: ({q + 1}, {r}), ({q - 1}, {r}), ({q}, {r + 1}), ({q}, {r - 1}), ({q + 1}, {r - 1}), ({q + 1}, {r + 1})");
            }
            else
            {
                // 짝수 행에 대한 이웃 노드 정의
                neighbors.Add(new Hex(q + 1, r)); // 오른쪽
                neighbors.Add(new Hex(q - 1, r)); // 왼쪽
                neighbors.Add(new Hex(q, r + 1)); // 위
                neighbors.Add(new Hex(q, r - 1)); // 아래
                neighbors.Add(new Hex(q - 1, r - 1)); // 왼쪽 아래
                neighbors.Add(new Hex(q - 1, r + 1)); // 왼쪽 위

                //Debug.Log($"Neighbors for Even Row: ({q + 1}, {r}), ({q - 1}, {r}), ({q}, {r + 1}), ({q}, {r - 1}), ({q - 1}, {r - 1}), ({q - 1}, {r + 1})");
            }
            neighbors = neighbors.FindAll(neighbor => GameManager.Instance.tilemap.HasTile(neighbor.ToVector3Int()));

            return neighbors;
        }
        //new overload for GetNeighbors
        public List<Hex> GetNeighbors(Tilemap tilemap = null)
        {
            List<Hex> neighbors = new List<Hex>();
            bool oddRow = Mathf.Abs(r % 2) == 1;

            if (oddRow)
            {
                neighbors.Add(new Hex(q + 1, r));
                neighbors.Add(new Hex(q - 1, r));
                neighbors.Add(new Hex(q, r + 1));
                neighbors.Add(new Hex(q, r - 1));
                neighbors.Add(new Hex(q + 1, r - 1));
                neighbors.Add(new Hex(q + 1, r + 1));
            }
            else
            {
                neighbors.Add(new Hex(q + 1, r));
                neighbors.Add(new Hex(q - 1, r));
                neighbors.Add(new Hex(q, r + 1));
                neighbors.Add(new Hex(q, r - 1));
                neighbors.Add(new Hex(q - 1, r - 1));
                neighbors.Add(new Hex(q - 1, r + 1));
            }

            // Tilemap이 제공되면 유효한 셀만 필터링
            if (tilemap != null)
            {
                neighbors = neighbors.FindAll(neighbor => tilemap.HasTile(neighbor.ToVector3Int()));
            }

            return neighbors;
        }



        public static int Distance(Hex a, Hex b)
        {
            int dq = Mathf.Abs(a.q - b.q);
            int dr = Mathf.Abs(a.r - b.r);
            int ds = Mathf.Abs((-a.q - a.r) - (-b.q - b.r));

            return Mathf.Max(dq, dr, ds);
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
            Hex start = new Hex(playerPosition);
            Hex goal = new Hex(mousePosition);

            Dictionary<Hex, Hex> cameFrom = new Dictionary<Hex, Hex>();
            Dictionary<Hex, int> costSoFar = new Dictionary<Hex, int>();

            PriorityQueue<Hex> frontier = new PriorityQueue<Hex>();
            frontier.Enqueue(start, 0);

            cameFrom[start] = null;
            costSoFar[start] = 0;

            while (frontier.Count > 0)
            {
                Hex current = frontier.Dequeue();

                if (current.Equals(goal)) break;

                foreach (Hex next in current.GetNeighbors(GameManager.Instance.tilemap))
                {
                    Vector3Int nextCell = next.ToVector3Int();

                    if (obstacles.Contains(next)) continue;

                    int newCost = costSoFar[current] + 1;
                    if (!costSoFar.TryGetValue(next, out int existingCost) || newCost < existingCost)
                    {
                        costSoFar[next] = newCost;
                        int priority = newCost + Hex.Heuristic(next, goal);
                        frontier.Enqueue(next, priority);
                        cameFrom[next] = current;
                    }
                }
            }

            if (!cameFrom.ContainsKey(goal))
            {
                Debug.LogError("경로를 찾을 수 없습니다.");
                return null;
            }

            List<Vector3Int> path = new List<Vector3Int>();
            Hex temp = goal;
            while (temp != null)
            {
                path.Insert(0, temp.ToVector3Int());
                temp = cameFrom[temp];
            }

            return path;
        }


    }

    public class PriorityQueue<T>
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
