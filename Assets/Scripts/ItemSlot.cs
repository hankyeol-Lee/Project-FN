using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image relicImage;          // 유물 이미지
    private Relic relic;              // 슬롯에 연결된 유물 데이터

    // 유물 데이터를 슬롯에 설정
public void SetRelic(Relic newRelic)
{
    relic = newRelic;

    if (relic != null)
    {
        relicImage.sprite = relic.Image; // Relic 이미지 반영
    }
}

    // 슬롯 초기화


    // 슬롯 클릭 시 동작
    public void OnSlotClick()
    {
        if (relic != null)
        {
            Debug.Log($"Clicked on relic: {relic.Name}");
            // 유물 사용 로직 추가 가능
        }
    }
}
