using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class BattleUI_CameraMove : MonoBehaviour
{
    public Transform playertransform; // HeroKnight�� Transform
    private float duration = 1.0f; // �̵��� �ɸ��� �ð�. �������� �ӵ��� ������

    public Vector3 MainCameraPos; // ó�� ī�޶� ��ġ(�ܾƿ� �Ǿ�������)

    private float deltax = 0.9217f; // Ÿ��ĳ���Ϳ��� x��ǥ ����
    private float deltay = 20.366f; // Ÿ��ĳ���Ϳ��� y��ǥ ����
    private bool isMoving = false;
    private bool isZoomin = false;

    private float startSize = 2.0f; // ���� ī�޶� ������
    private float targetSize = 1.02f; // ��ǥ ī�޶� ������

    private void Start()
    {
        MainCameraPos = transform.position; // �ܾƿ� �Ǿ��������� �������� ����.
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isMoving && !isZoomin) // EŰ�� ���� �̵� ����
        {
            StartCoroutine(MoveCamera_In());
        }
        if (isZoomin && !isMoving && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine (MoveCamera_Out());
        }
    }

    IEnumerator MoveCamera_In()
    {
        isMoving = true;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3(playertransform.position.x + deltax, playertransform.position.y + deltay, transform.position.z);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            // ���� ���� (Lerp)
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            Camera.main.orthographicSize = Mathf.Lerp(startSize, targetSize, t);

            yield return null;
        }

        transform.position = targetPosition;
        Camera.main.orthographicSize = targetSize;

        isMoving = false;
        isZoomin = true;
    }
    IEnumerator MoveCamera_Out()
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = MainCameraPos;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            // ���� ���� (Lerp)
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            Camera.main.orthographicSize = Mathf.Lerp(targetSize, startSize, t);

            yield return null;
        }

        transform.position = targetPosition; //�ٽ� Ȯ��� ī�޶� ��ġ�� ���ư�.
        Camera.main.orthographicSize = startSize; //�ٽ� ���� ũ��� ���ư�.

        isMoving = false;
        isZoomin = false;
    }
}
