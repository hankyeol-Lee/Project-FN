using System.Collections.Generic;
using UnityEngine;

namespace HexClass // pathfinding �޼ҵ�� �ٸ� ��ü������ ��� �����ϵ���, namespace�� ����.
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
            // Hash code ����
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + q.GetHashCode();
                hash = hash * 31 + r.GetHashCode();
                
                return hash;
            }
        }

        public List<Hex> GetNeighbors(Hex goal) // �ֺ� Hex
        {
            List<Hex> neighbors = new List<Hex>
            {
                new Hex(q + 1, r), //��
                new Hex(q - 1, r), // �Ʒ�
                new Hex(q, r + 1), // ������ ��
                new Hex(q, r - 1), // ���� ��
                new Hex(q + 1, r - 1), // ���� �Ʒ�
                new Hex(q - 1, r + 1) // ������ �Ʒ�
            };
            neighbors.Sort((a, b) =>
            {
                int aDist = Hex.Distance(a, goal);
                int bDist = Hex.Distance(b, goal);
                return aDist.CompareTo(bDist); // ��ǥ�� �� ����� ������ �켱
            });


            return neighbors;
        }

        public static int Distance(Hex a, Hex b)
        {
            return Mathf.Max(Mathf.Abs(a.q - b.q), Mathf.Abs(a.r - b.r), Mathf.Abs((-a.q - a.r) - (-b.q - b.r))); //����ư �Ÿ� ���� ť�� �Ÿ��� ���.
        }

        public static int Heuristic(Hex a, Hex b)
        {
            return Distance(a, b);
        }
    }

    public class HexPathfinding // A* �˰���
    {
        public static List<Vector3Int> FindPath(Vector3Int playerPosition, Vector3Int mousePosition, HashSet<Hex> obstacles)
        {
            Hex start = new Hex(playerPosition); // �÷��̾� ��ġ�� �ִ� hex�� start��� ����
            Hex goal = new Hex(mousePosition); // ���콺�� ����, ��ǥ ������ goal�̶�� hex�� ����

            Dictionary<Hex, Hex> cameFrom = new Dictionary<Hex, Hex>(); // ���� hex�� �� �� hex�� �����ϴ� ��ųʸ�
            Dictionary<Hex, int> costSoFar = new Dictionary<Hex, int>(); // �� ĭ�� �ɸ����� �����ϴ� ��ųʸ�

            PriorityQueue<Hex> frontier = new PriorityQueue<Hex>(); // frontier��� �켱���� ť ����.
            frontier.Enqueue(start, 0); // ť�� ù��° ���ҷ� start�� ����.

            cameFrom[start] = null;
            costSoFar[start] = 0;

            while (frontier.Count > 0)
            {
                Hex current = frontier.Dequeue(); // ���� hex, �� ���� ť�� ���� ù���� ��. ù��° ������ ���� ��ġ�� ����Ŵ.

                if (current.Equals(goal)) // ���� ����� goal�� �Ȱ��� ���, ��ġ�� ���������Ƿ� ����.
                    break;

                List<Hex> neighbors = current.GetNeighbors(goal);
                foreach (Hex next in neighbors) // �̿��� ��带 ����.
                {
                    // ��ֹ� �˻�
                    if (obstacles.Contains(next)) // ��ֹ��̸� ����
                        continue;

                    int newCost = costSoFar[current] + 1; 
                    if (!costSoFar.TryGetValue(next, out int existingCost) || newCost <= existingCost) // ��带 ó�� �湮�ϰų� �Ǵ� ���� ����� ��뺸�� �� ���� ���
                    {
                        costSoFar[next] = newCost; // �󸶳� �ɸ����� ������Ʈ.
                        int priority = newCost + Hex.Heuristic(next, goal); // �켱���� ����. �޸���ƽ �Լ��� �̿��� ����ĭ�� ��ǥ���� �󸶳� �ɸ����� üũ
                        frontier.Enqueue(next, priority); // �켱���� ť�� ����.
                        cameFrom[next] = current; // ��� �Դ����� ������.
                    }
                }
            }

            List<Vector3Int> path = new List<Vector3Int>(); // �̵���θ� ������ path ����Ʈ ����.
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


    public class PriorityQueue<T> //�켱���� ť Ŭ����. ���������� ������ ������ ������, Enqueue�Ҷ� ���� sort�ϰ� ��.
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
