using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillHexRadius : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void ScaleHex(Vector3Int mouseCellPos,int scale)
    {
        this.gameObject.SetActive(true);

        // ������Ʈ ��ġ�� �浹 �������� ����
        transform.position = mouseCellPos;

        // �⺻ ������ ���� ����
        float baseXScale = 0.2668313f;
        float baseYScale = 0.1377698f;
        float baseZScale = 0.2298f;

        // �����Ͽ� ����Ͽ� ������ ũ�� ����
        float hexWidthScale = baseXScale * scale;
        float hexHeightScale = baseYScale * scale;
        float hexDepthScale = baseZScale * scale;

        // x, y, z �� ������ �����Ͽ� ������ ���·� �����ϸ�
        transform.localScale = new Vector3(hexWidthScale, hexHeightScale, hexDepthScale);
        
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
