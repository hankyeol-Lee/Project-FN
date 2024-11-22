using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image relicImage;          // ���� �̹���
    private Relic relic;              // ���Կ� ����� ���� ������

    // ���� �����͸� ���Կ� ����
public void SetRelic(Relic newRelic)
{
    relic = newRelic;

    if (relic != null)
    {
        relicImage.sprite = relic.Image; // Relic �̹��� �ݿ�
    }
}

    // ���� �ʱ�ȭ


    // ���� Ŭ�� �� ����
    public void OnSlotClick()
    {
        if (relic != null)
        {
            Debug.Log($"Clicked on relic: {relic.Name}");
            // ���� ��� ���� �߰� ����
        }
    }
}
