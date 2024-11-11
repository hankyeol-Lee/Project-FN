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

        // 오브젝트 위치를 충돌 지점으로 설정
        transform.position = mouseCellPos;

        // 기본 육각형 비율 설정
        float baseXScale = 0.2668313f;
        float baseYScale = 0.1377698f;
        float baseZScale = 0.2298f;

        // 스케일에 비례하여 육각형 크기 조정
        float hexWidthScale = baseXScale * scale;
        float hexHeightScale = baseYScale * scale;
        float hexDepthScale = baseZScale * scale;

        // x, y, z 축 비율을 적용하여 육각형 형태로 스케일링
        transform.localScale = new Vector3(hexWidthScale, hexHeightScale, hexDepthScale);
        
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
