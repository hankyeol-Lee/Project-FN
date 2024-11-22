using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

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

        public List<Hex> GetNeighbors()
        {
            List<Hex> neighbors = new List<Hex>();

            bool oddRow = Mathf.Abs(r % 2) == 1;
            //Debug.Log($"Current Hex: ({q}, {r}), Odd Row: {oddRow}");

            if (oddRow)
            {
                // Ȧ�� �࿡ ���� �̿� ��� ����
                neighbors.Add(new Hex(q + 1, r)); // ������
                neighbors.Add(new Hex(q - 1, r)); // ����
                neighbors.Add(new Hex(q, r + 1)); // ��
                neighbors.Add(new Hex(q, r - 1)); // �Ʒ�
                neighbors.Add(new Hex(q + 1, r - 1)); // ������ �Ʒ�
                neighbors.Add(new Hex(q + 1, r + 1)); // ������ ��

                //Debug.Log($"Neighbors for Odd Row: ({q + 1}, {r}), ({q - 1}, {r}), ({q}, {r + 1}), ({q}, {r - 1}), ({q + 1}, {r - 1}), ({q + 1}, {r + 1})");
            }
            else
            {
                // ¦�� �࿡ ���� �̿� ��� ����
                neighbors.Add(new Hex(q + 1, r)); // ������
                neighbors.Add(new Hex(q - 1, r)); // ����
                neighbors.Add(new Hex(q, r + 1)); // ��
                neighbors.Add(new Hex(q, r - 1)); // �Ʒ�
                neighbors.Add(new Hex(q - 1, r - 1)); // ���� �Ʒ�
                neighbors.Add(new Hex(q - 1, r + 1)); // ���� ��

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

            // Tilemap�� �����Ǹ� ��ȿ�� ���� ���͸�
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

                List<Hex> neighbors = current.GetNeighbors();
                foreach (Hex next in neighbors) // �̿��� ��带 ����.
                {
                    // ��ֹ� �˻�
                    Vector3Int nextCell = next.ToVector3Int();

                    if (!GameManager.Instance.tilemap.HasTile(nextCell) || obstacles.Contains(next)) // ��ֹ��̸� ����
                        continue;

                    int newCost = costSoFar[current] + 1;
                    if (!costSoFar.TryGetValue(next, out int existingCost) || newCost < existingCost) // ��带 ó�� �湮�ϰų� �Ǵ� ���� ����� ��뺸�� �� ���� ���
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

            if (!cameFrom.ContainsKey(goal)) // ��ǥ�� �������� ���� ��� üũ
            {
                Debug.LogError("��θ� ã�� �� �����ϴ�.");
                return null;
            }

            while (temp != null)
            {
                path.Add(temp.ToVector3Int());
                temp = cameFrom[temp];
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
