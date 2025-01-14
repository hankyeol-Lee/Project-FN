using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleUI_CameraMove : MonoBehaviour
{
    public Transform playertransform; // HeroKnight의 Transform
    private float duration = 0.5f; // 이동에 걸리는 시간. 작을수록 속도가 빨라짐

    public Vector3 MainCameraPos; // 처음 카메라 위치(줌아웃 되어있을때)

    private float deltax = 0.9217f; // 타겟캐릭터와의 x좌표 차이
    private float deltay = 20.366f; // 타겟캐릭터와의 y좌표 차이
    private bool isMoving = false;
    private bool isZoomin = false;

    private float startSize = 2.0f; // 시작 카메라 사이즈
    private float targetSize = 1.02f; // 목표 카메라 사이즈

    public string uiSceneName = "BattleUIScene";
    private bool isUISceneLoaded = false;

    private void Start()
    {
        MainCameraPos = transform.position; // 줌아웃 되어있을때를 기준으로 설정.
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isMoving && !isZoomin) // E키를 눌러 이동 시작
        {
            StartCoroutine(MoveCamera_In());
        }
        if (isZoomin && !isMoving && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(MoveCamera_Out());
        }
    }

    IEnumerator MoveCamera_In()
    {
        isMoving = true;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3(playertransform.position.x + deltax, playertransform.position.y + deltay, transform.position.z);
        float elapsedTime = 0f;
        float power = 2.0f; // 비선형 보간의 강도 조절 변수

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            // 비선형 보간 (t^power)
            float powT = Mathf.Pow(t, power);
            transform.position = Vector3.Lerp(startPosition, targetPosition, powT);
            Camera.main.orthographicSize = Mathf.Lerp(startSize, targetSize, powT);

            yield return null;
        }

        transform.position = targetPosition;
        Camera.main.orthographicSize = targetSize;

        isMoving = false;
        isZoomin = true;

        SceneManager.LoadScene(uiSceneName, LoadSceneMode.Additive);
        isUISceneLoaded = true;
    }

    IEnumerator MoveCamera_Out()
    {
        SceneManager.UnloadSceneAsync(uiSceneName); // 씬 끄기(임시, 다른 코드로 옮겨야함.)
        isUISceneLoaded = false;

        isMoving = true;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = MainCameraPos;
        float elapsedTime = 0f;
        float power = 2.0f; // 비선형 보간의 강도 조절 변수

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            // 비선형 보간 (t^power)
            float powT = Mathf.Pow(t, power);
            transform.position = Vector3.Lerp(startPosition, targetPosition, powT);
            Camera.main.orthographicSize = Mathf.Lerp(targetSize, startSize, powT);

            yield return null;
        }

        transform.position = targetPosition; //다시 확대된 카메라 위치로 돌아감.
        Camera.main.orthographicSize = startSize; //다시 원래 크기로 돌아감.

        isMoving = false;
        isZoomin = false;
    }
}
