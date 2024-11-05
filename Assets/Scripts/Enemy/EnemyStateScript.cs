using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class EnemyStateScript : MonoBehaviour
{
    // ���¸� �����ϴ� enum
    public enum EnemyState { Wait, Move, Attack }
    public EnemyState enemyState = EnemyState.Wait; // �ʱ� ���´� Wait

    public GameObject enemy; // Enemy ��ü
    public Transform playertransform;
    public Vector3 nextCellPosition; // ���� �̵��� Cell�� ��ġ

    public Tilemap tilemap;

    private void Start()
    {
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
                    enemyState = EnemyState.Move; // ���¸� Move�� ����
                    //Debug.Log($"2�� ����. ���� EnemyState : {enemyState}");
                    break;

                case EnemyState.Move:
                    // �̵� ���·� ��ȯ�ϸ� �̵� �ڷ�ƾ ����
                    //Debug.Log($"���� EnemyState : {enemyState}");
                    //Vector3 startWorldPos = enemy.transform.position;
                    yield return StartCoroutine(MoveCell(enemy, CellCenterPos(enemy.transform.position), nextCellPos()));

                    // �̵��� ������ �ٽ� Wait ���·� ��ȯ�ϰ� 2�� ���
                    enemyState = EnemyState.Wait;
                    yield return new WaitForSeconds(2f);
                    break;

                // �ʿ��� ��� Attack ���¸� �߰������� ������ �� ����
                case EnemyState.Attack:
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
        Vector3Int enemyPos = tilemap.WorldToCell(enemy.transform.position);
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
}
