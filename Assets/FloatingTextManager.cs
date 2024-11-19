using UnityEngine;
using TMPro;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject floatingTextPrefab; // ������ ����
    public float floatDuration = 1.5f;    // �ؽ�Ʈ ǥ�� �ð�
    public Vector3 offset = new Vector3(10, 15, 0); // ��ġ ������

    public Canvas canvas; // Inspector���� Canvas ����

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
