using UnityEngine;
using TMPro;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject floatingTextPrefab; // ������ ����
    public float floatDuration = 1.5f;    // �ؽ�Ʈ ǥ�� �ð�
    public Vector3 offset = new Vector3(10, 15, 0); // ��ġ ������
    public GameObject canvasInstance;
    public Canvas canvas; // Inspector���� Canvas ����
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
        //Debug.Log(canvas.transform); // ���⿡�� missing referenceException. canvas�� �� ������°��� instantiate�ߴµ� 
        Debug.Log(floatingTextPrefab);
        //canvas.transform.position = position;
        floatingText = Instantiate(floatingTextPrefab, canvas.transform); // ���⿡�� ����
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
