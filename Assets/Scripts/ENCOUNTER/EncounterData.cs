using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Encounter", menuName = "Encounter System/Encounter Data")]
public class EncounterData : ScriptableObject
{
    // Start is called before the first frame update
    public string encounterName; // 인카운터 이름
    [TextArea] public string encounterDescription; // 인카운터 설명 대사
    public List<string> choices; // 선택지 목록 (0~7개)
}
