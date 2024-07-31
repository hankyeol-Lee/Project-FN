using System.Collections.Generic;
using UnityEngine;

namespace HexClass // pathfinding 메소드는 다른 객체에서도 사용 가능하도록, namespace로 저장.
{
    public class Hex
    {
        public int q, r, s;

        public Hex(int q, int r)
        {
            this.q = q;
            this.r = r;
            this.s = -q - r; // q, r, s의 합은 항상 0을 유지해야 함.
        }

        public Hex(Vector3Int vec)
        {
            this.q = vec.x;
            this.r = vec.y;
            this.s = -vec.x - vec.y; // 큐브 좌표로 변환 시 규칙을 따름
        }

        public Vector3Int ToVector3Int()
        {
            return new Vector3Int(q, r, s);
        }

        public override bool Equals(object obj)
        {
            if (obj is Hex other)
            {
                return q == other.q && r == other.r && s == other.s;
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
                hash = hash * 31 + s.GetHashCode();
                return hash;
            }
        }

        public List<Hex> GetNeighbors() // 주변 Hex
        {
            List<Hex> neighbors = new List<Hex>
            {
                new Hex(q + 1, r),
                new Hex(q - 1, r),
                new Hex(q, r + 1),
                new Hex(q, r - 1),
                new Hex(q + 1, r - 1),
                new Hex(q - 1, r + 1)
            };

            return neighbors;
        }

        public static int Distance(Hex a, Hex b)
        {
            return (Mathf.Abs(a.q - b.q) + Mathf.Abs(a.r - b.r) + Mathf.Abs(a.s - b.s)) / 2;
        }

        public static int Heuristic(Hex a, Hex b)
        {
            return Distance(a, b);
        }
    }

    public class HexPathfinding // A* 알고리즘
    {
        public static List<Vector3Int> FindPath(Vector3Int playerPosition, Vector3Int mousePosition)
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

                if (current.Equals(goal))
                    break;

                foreach (Hex next in current.GetNeighbors())
                {
                    int newCost = costSoFar[current] + 1; // Assuming cost of 1 for each step
                    if (!costSoFar.TryGetValue(next, out int existingCost) || newCost < existingCost)
                    {
                        costSoFar[next] = newCost;
                        int priority = newCost + Hex.Heuristic(next, goal);
                        frontier.Enqueue(next, priority);
                        cameFrom[next] = current;
                    }
                }
            }

            List<Vector3Int> path = new List<Vector3Int>();
            Hex temp = goal;

            while (temp != null)
            {
                if (!cameFrom.TryGetValue(temp, out Hex prev))
                {
                    Debug.LogError($"Pathfinding error: No path from {temp.q},{temp.r},{temp.s}");
                    break;
                }
                path.Add(temp.ToVector3Int());
                temp = prev;
            }

            path.Reverse();
            return path;
        }
    }

    // Simple priority queue implementation using a sorted list
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
