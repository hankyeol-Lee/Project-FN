using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using Enemyspace;

public class EnemyStateScript : MonoBehaviour
{
    // ���¸� �����ϴ� enum
    public enum EnemyState { Wait, Move, Attack }
    public EnemyState enemyState = EnemyState.Wait; // �ʱ� ���´� Wait

    public GameObject enemyobject; // Enemy ��ü
    public Transform playertransform;
    public Vector3 nextCellPosition; // ���� �̵��� Cell�� ��ġ
    public Enemy enemy;
    public Tilemap tilemap;
    public ActiveSkill thisSkill;

    private void OnEnable()
    {
        enemyobject = transform.parent.gameObject;
        string cleanedName = enemyobject.name.Replace("(Clone)", "").Trim();
        enemyobject.name = cleanedName;
        playertransform = GameManager.Instance.player.GetComponent<Transform>();
        tilemap = GameManager.Instance.tilemap;

        if (EnemyInstances.enemyDict.TryGetValue(cleanedName, out Enemy enemy))
        {
            this.enemy = enemy;
            thisSkill = enemy.enemySkillList[0];
        }
        else
        {
            Debug.LogWarning($"{enemyobject}����� ���� �ȵƾ��.");
        }

        // ���� ���� �ڷ�ƾ ����
        StartCoroutine(StateManager());
    }

    // ���¸� �����ϴ� �ڷ�ƾ
    private IEnumerator StateManager()
    {
        while (true)
        {
            switch (enemyState)
            {
                case EnemyState.Wait:
                    yield return new WaitForSeconds(1f);

                    if (checkDistancetoPlayer()) // ���� �Ÿ� Ȯ��
                    {
                        enemyState = EnemyState.Attack;
                    }
                    else
                    {
                        enemyState = EnemyState.Move; // Move ���·� ��ȯ
                    }
                    break;

                case EnemyState.Move:
                    Vector3 startWorldPos = enemyobject.transform.position;
                    Vector3 endWorldPos = nextCellPos();

                    // �̵� �ڷ�ƾ ����
                    yield return StartCoroutine(MoveCell(enemyobject, startWorldPos, endWorldPos));

                    // �̵� �� �ٽ� Wait ���·� ��ȯ
                    enemyState = EnemyState.Wait;
                    yield return new WaitForSeconds(2f);
                    break;

                case EnemyState.Attack:
                    yield return new WaitForSeconds(0.5f);
                    enemy.Attack(enemyobject);
                    enemyState = EnemyState.Wait;
                    break;
            }
        }
    }

    // ���� �̵��� ���� ���� ��ǥ ���
    private Vector3 nextCellPos()
    {
        Vector3Int enemyPos = tilemap.WorldToCell(enemyobject.transform.position);
        Vector3Int playerPos = tilemap.WorldToCell(playertransform.position);

        // �÷��̾� �������� Ÿ���� �ִ� ��ȿ�� ��ġ�� ���
        Vector3Int targetPos = GetValidTargetPos(enemyPos, playerPos);

        return tilemap.CellToWorld(targetPos); // Ÿ�ϸ� ��ǥ�� ���� ��ǥ�� ��ȯ
    }

    // ��ȿ�� Ÿ�� ��ġ�� ��ȯ
    private Vector3Int GetValidTargetPos(Vector3Int enemyPos, Vector3Int playerPos)
    {
        Vector3Int[] possibleMoves = new Vector3Int[]
        {
            new Vector3Int(enemyPos.x + 1, enemyPos.y, 0),
            new Vector3Int(enemyPos.x - 1, enemyPos.y, 0),
            new Vector3Int(enemyPos.x, enemyPos.y + 1, 0),
            new Vector3Int(enemyPos.x, enemyPos.y - 1, 0)
        };

        Vector3Int bestMove = enemyPos;
        float shortestDistance = float.MaxValue;

        foreach (Vector3Int move in possibleMoves)
        {
            if (tilemap.HasTile(move)) // Ÿ�� ��ȿ�� Ȯ��
            {
                float distance = Vector3Int.Distance(move, playerPos);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    bestMove = move;
                }
            }
        }

        return bestMove; // ��ȿ�� ��ġ ��ȯ
    }

    // ��ü�� �̵���Ű�� MoveCell �ڷ�ƾ
    private IEnumerator MoveCell(GameObject mover, Vector3 startWorldPos, Vector3 endWorldPos)
    {
        float elapsedTime = 0f;
        float duration = 0.5f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            mover.transform.position = Vector3.Lerp(startWorldPos, endWorldPos, t);
            yield return null;
        }

        // ��Ȯ�� ��ǥ ��ġ�� ����
        mover.transform.position = endWorldPos;
    }

    // �÷��̾���� �Ÿ� Ȯ��
    private bool checkDistancetoPlayer()
    {
        int GetHexTileDistance(Vector3 enemyWorldPos, Vector3 playerWorldPos)
        {
            Vector3 enemyCellCenter = CellCenterPos(enemyWorldPos);
            Vector3 playerCellCenter = CellCenterPos(playerWorldPos);

            Vector3Int CubeCoordinates(Vector3Int cellPos)
            {
                int x = cellPos.x;
                int z = cellPos.y - (cellPos.x + (cellPos.x & 1)) / 2; // ť�� ��ǥ ��ȯ (Even-r ����)
                int y = -x - z;
                return new Vector3Int(x, y, z);
            }

            Vector3Int enemyCell = tilemap.WorldToCell(enemyCellCenter);
            Vector3Int playerCell = tilemap.WorldToCell(playerCellCenter);

            Vector3Int enemyCube = CubeCoordinates(enemyCell);
            Vector3Int playerCube = CubeCoordinates(playerCell);

            return Mathf.Max(
                Mathf.Abs(enemyCube.x - playerCube.x),
                Mathf.Abs(enemyCube.y - playerCube.y),
                Mathf.Abs(enemyCube.z - playerCube.z)
            );
        }

        return GetHexTileDistance(enemyobject.transform.position, playertransform.position) <= thisSkill.distance;
    }

    // ���� ��ǥ�� �� �߽� ��ǥ ��ȯ
    private Vector3 CellCenterPos(Vector3 worldTransform)
    {
        Vector3Int cellPos = tilemap.WorldToCell(worldTransform);
        return tilemap.CellToWorld(cellPos);
    }
}
