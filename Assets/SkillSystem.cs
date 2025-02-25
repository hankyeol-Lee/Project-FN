using GameSkill;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SkillSystem : MonoBehaviour
{
    public GameObject player; // 여기에서 플레이어의 스킬 목록도 따올거임.
    public Tilemap tilemap;
    public GameObject skillRange;
    private PlayerSkill playerskill;
    public Skill[] skills;
    private void Start()
    {
        PlayerSkill playerskill = player.GetComponent<PlayerSkill>(); // playerskill.cs를 가져옴
        if (playerskill != null) //nullcheck
        {
            skills = playerskill.playerSkills; // 배열 자체를 직접 가져오기
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShowSkillRange(skills[0]);
            //skills[0];
            //if (skillRange.activeSelf == true) { Debug.Log("이건 ok"); }

        }
        if (skillRange.activeSelf == true && Input.GetMouseButton(0)) // 사거리가 켜져있는데, 좌클릭도 눌렀으면.
        {
            Vector3Int? checkMouseCell = CheckMouseInCircle();
            if (checkMouseCell.HasValue)
            {
                Debug.Log($"스킬을 쓴 위치는 :{checkMouseCell}");
                //TODO : 1. 스킬 쓴 위치 주변으로 사거리 표시. 사거리는 skill에 있어야함.
                //2. 이제 skill을 캐스팅해야함.캐스팅하는 로직? 도 생각하셈.
                //그러니까 skill을 어떤 식으로 저장할건지 생각하셈 그거부터.
                skillRange.SetActive(false);
            }
        }
        /*
        if (skillRange.activeSelf && Input.GetMouseButton(1))
        {
            skillRange.SetActive(false);
        }
        */

    }
    private void ShowSkillRange(Skill skill)
    {
        float skillrange = skill.Range;
        //range만큼 이제 사거리를 표시해줘야 함. -> skill 사용이 끝나면 다시 deactivate 해야함.
        skillRange.GetComponent<CircleRangeSize>().UpdateCircleSize(skillrange);
    }



    private Vector3Int? CheckMouseInCircle() // 마우스가 만약 사거리 안에 있고, 타일 안에 있다면 타일의 좌표를 반환, 그렇지 않다면 null을 반환.
    {
        // 마우스 위치를 기준으로 Ray 생성
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray);

        bool hitCircle = false;
        bool hitCell = false;
        // Ray가 닿은 모든 오브젝트 확인
        foreach (var hit in hits)
        {
            // 태그 또는 이름을 통해 원과 cell을 구분
            if (hit.collider.CompareTag("skillRange"))
            {
                hitCircle = true;
            }
            if (hit.collider.CompareTag("Cell"))
            {
                hitCell = true;
            }
        }
        // 두 오브젝트가 모두 닿았는지 확인
        if (hitCircle && hitCell)
        {
            Debug.Log("마우스가 원과 cell에 모두 닿아 있습니다.");
            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Cell"))
                {
                    Vector3 worldPosition = hit.point;
                    Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
                    //Debug.Log($"리턴 셀좌표 : {cellPosition}");
                    return cellPosition;
                }
            }
        }

        return null;
    }
}

