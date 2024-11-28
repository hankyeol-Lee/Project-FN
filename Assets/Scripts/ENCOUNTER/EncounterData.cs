using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Encounter", menuName = "Encounter System/Encounter Data")]
public class EncounterData : ScriptableObject
{
    // Start is called before the first frame update
    public string encounterName; // ��ī���� �̸�
    [TextArea] public string encounterDescription; // ��ī���� ���� ���
    public List<string> choices; // ������ ��� (0~7��)
}
