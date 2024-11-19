using UnityEngine;
using TMPro;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject floatingTextPrefab; // 프리팹 연결
    public float floatDuration = 1.5f;    // 텍스트 표시 시간
    public Vector3 offset = new Vector3(10, 15, 0); // 위치 오프셋

    public Canvas canvas; // Inspector에서 Canvas 연결

    public void ShowFloatingText(Vector3 position, float damage)
    {
        position = Camera.main.WorldToScreenPoint(position);
        Debug.Log(position);
        GameObject floatingText = Instantiate(floatingTextPrefab, canvas.transform);
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
