using UnityEngine;
using TMPro;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject floatingTextPrefab; // 프리팹 연결
    public float floatDuration = 1.5f;    // 텍스트 표시 시간
    public Vector3 offset = new Vector3(10, 15, 0); // 위치 오프셋
    public GameObject canvasInstance;
    public Canvas canvas; // Inspector에서 Canvas 연결
    public void Start()
    {
        canvasInstance = Instantiate(canvas.gameObject);
        canvas = canvasInstance.GetComponent<Canvas>();
    }
    public void ShowFloatingText(Vector3 position, float damage)
    {
        //canvas = Resources.Load<Canvas>("Prefab/TextCanvas");
        position = Camera.main.WorldToScreenPoint(position);
        Debug.Log(position);
        GameObject? floatingText;
        //Debug.Log(canvas.transform); // 여기에서 missing referenceException. canvas가 왜 사라지는거지 instantiate했는데 
        Debug.Log(floatingTextPrefab);
        //canvas.transform.position = position;
        floatingText = Instantiate(floatingTextPrefab, canvas.transform); // 여기에서 문제
        Debug.Log(floatingText);
        floatingText.transform.position = position + offset;

        TextMeshProUGUI textMesh = floatingText.GetComponent<TextMeshProUGUI>();
        if (textMesh != null)
        {
            textMesh.text = $"-{damage}";
            textMesh.color = Color.red;
        }
        Destroy(floatingText, floatDuration);
    }

}
