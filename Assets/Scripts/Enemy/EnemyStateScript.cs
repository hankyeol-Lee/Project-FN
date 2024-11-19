using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
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

    private void Start()
    {
        enemyobject = transform.parent.gameObject;
        playertransform = GameManager.Instance.player.GetComponent<Transform>();
        tilemap = GameManager.Instance.tilemap;
        Debug.Log(enemyobject.name);
        if(EnemyInstances.enemyDict.TryGetValue(enemyobject.name,out Enemy enemy))
        {
            this.enemy = enemy;
            thisSkill = enemy.enemySkillList[0];
        }
        else
        {
            Debug.LogWarning($"{enemyobject}����� ���� �ȵƾ��.");
        }

        // �ڷ�ƾ�� �����ؼ� 2�� �� ���¸� Move�� �ٲ�
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
                    // Wait ���¿����� 2�ʸ� ���
                    yield return new WaitForSeconds(2f);
                    // ���� �÷��̾���� �� �Ÿ��� thisskill.skillcelldist ���϶�� if (thisSkill.skillcelldist)
                    if (checkDistancetoPlayer())
                    {
                        enemyState = EnemyState.Attack;
                        Debug.Log(enemyState);
                    }
                    else
                    {
                        enemyState = EnemyState.Move; // ���¸� Move�� ����
                        Debug.Log(enemyState);
                    }
                    Debug.Log(enemyState);
                    //Debug.Log($"2�� ����. ���� EnemyState : {enemyState}");
                    //TODO : ���⿡�� 2�� ��ٸ��� �ִϸ��̼� �����ؾ��� ����
                    break;

                case EnemyState.Move:
                    // �̵� ���·� ��ȯ�ϸ� �̵� �ڷ�ƾ ����
                    //Debug.Log($"���� EnemyState : {enemyState}");
                    //Vector3 startWorldPos = enemy.transform.position;
                    yield return StartCoroutine(MoveCell(enemyobject, CellCenterPos(enemyobject.transform.position), nextCellPos()));

                    // �̵��� ������ �ٽ� Wait ���·� ��ȯ�ϰ� 2�� ���
                    enemyState = EnemyState.Wait;
                    Debug.Log(enemyState);
                    yield return new WaitForSeconds(2f);
                    break;

                case EnemyState.Attack:
                    yield return new WaitForSeconds(1f);
                    enemy.Attack(enemyobject);
                    enemyState = EnemyState.Wait;
                    // Attack ���¿����� ���� (�߰����� ���ǿ� ���� ����)
                    break;
            }

            // ���� ������ �ƴ϶� Ư�� ���ǿ��� �����ϰ� �ʹٸ� ���� ���� �߰� ����
        }
    }
    
    private Vector3 nextCellPos() // Enemy�� �̵��� ���� cell�� ���ϴ� �ڵ�.
    {
        void SettargetPos(Vector3Int thisObjPos, Vector3Int playerPos, ref Vector3Int targetPos)
        {
            bool isOddRow = Mathf.Abs(thisObjPos.y % 2) == 1; // Ȧ�� ������ Ȯ��
            bool isPlayerOnRight = playerPos.y > thisObjPos.y; // �÷��̾ �� �����ʿ� �ִ��� �Ǵ�
            if (playerPos.y == thisObjPos.y) // ���� �࿡ �ִ� ���
            {
                targetPos.x += (playerPos.x > thisObjPos.x) ? 1 : -1; // �÷��̾ �����̸� +1, �ƴϸ� -1
            }
            else if (isPlayerOnRight) // �÷��̾ �����ʿ� �ִ� ���
            {
                targetPos.y += 1;
                if (isOddRow)
                {
                    targetPos.x += UnityEngine.Random.Range(0, 2) == 0 ? 1 : 0;
                }
                else
                {
                    targetPos.x -= UnityEngine.Random.Range(0, 2) == 0 ? 1 : 0;
                }
            }
            else // �÷��̾ ���ʿ� �ִ� ���
            {
                targetPos.y -= 1;
                if (isOddRow)
                {
                    targetPos.x += UnityEngine.Random.Range(0, 2) == 0 ? 1 : 0;

                }
                else
                {
                    targetPos.x -= UnityEngine.Random.Range(0, 2) == 0 ? 1 : 0;
                }
            }
        }
        Vector3Int enemyPos = tilemap.WorldToCell(enemyobject.transform.position);
        Vector3Int playerPos = tilemap.WorldToCell(playertransform.position);
        Vector3Int targetPos = enemyPos;
        SettargetPos(enemyPos,playerPos,ref targetPos); // targetPos�� ��ġ�� ����� ����.
        //Debug.Log($"������ �̵��� �� : {targetPos}");
        return tilemap.CellToWorld(targetPos); // targetPos�� ������ǥ�� ��ȯ.
    }
    

    // ��ü�� �̵���Ű�� MoveCell �ڷ�ƾ
    IEnumerator MoveCell(GameObject mover, Vector3 startWorldPos, Vector3 endWorldPos)
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

        // ��Ȯ�ϰ� ��ǥ ��ġ�� ����
        mover.transform.position = endWorldPos;
    }

    public Vector3 CellCenterPos(Vector3 worldTransform) // �� ��ǥ�� �ִ� ���� �߾� ��ǥ�� ��ȯ.
    {
        Vector3Int cellPos = tilemap.WorldToCell(worldTransform);

        return tilemap.CellToWorld(cellPos); // ������ǥ�� ��ȯ.
    }
    
    private bool checkDistancetoPlayer()
    {
        int GetHexTileDistance(Vector3 enemyWorldPos, Vector3 playerWorldPos)
        {
            // ���� �÷��̾��� �� �߽� ��ǥ ���
            Vector3 enemyCellCenter = CellCenterPos(enemyWorldPos);
            Vector3 playerCellCenter = CellCenterPos(playerWorldPos);

            // �� ��ǥ�� ť�� ��ǥ�� ��ȯ�ϴ� �Լ�
            Vector3Int CubeCoordinates(Vector3Int cellPos)
            {
                int x = cellPos.x;
                int z = cellPos.y - (cellPos.x + (cellPos.x & 1)) / 2; // Even-r ����
                int y = -x - z;
                return new Vector3Int(x, y, z);
            }

            // ���� ��ǥ -> �� ��ǥ ��ȯ
            Vector3Int enemyCell = tilemap.WorldToCell(enemyCellCenter);
            Vector3Int playerCell = tilemap.WorldToCell(playerCellCenter);

            // �� ��ǥ -> ť�� ��ǥ ��ȯ
            Vector3Int enemyCube = CubeCoordinates(enemyCell);
            Vector3Int playerCube = CubeCoordinates(playerCell);

            // ť�� �Ÿ� ���
            int distance = Mathf.Max(
                Mathf.Abs(enemyCube.x - playerCube.x),
                Mathf.Abs(enemyCube.y - playerCube.y),
                Mathf.Abs(enemyCube.z - playerCube.z)
            );

            return distance;
        }
        if (GetHexTileDistance(enemyobject.transform.position,GameManager.Instance.player.transform.position) <= thisSkill.distance)
        {
            return true;
        }
        return false;
    }
}
