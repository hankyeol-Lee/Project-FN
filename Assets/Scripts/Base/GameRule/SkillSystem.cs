using UnityEngine;
using UnityEngine.Tilemaps;

public class SkillSystem : MonoBehaviour
{
    public GameObject player; // 여기에서 플레이어의 스킬 목록도 따올거임.
    public Tilemap tilemap;
    public GameObject skillRange; // 사거리.
    private PlayerSkill playerskill;
    public ActiveSkill[] skills;
    public GameObject skillTargetObject; // 대상지정 스킬의 타겟
    public ActiveSkill thisSkill; // 키를 눌렀을 때, 어떤 스킬을 쓰는지 check하는 스킬을 가리키는 변수.

    private Vector3Int? lastMouseCell = null; // 마지막으로 머물렀던 셀 좌표 저장


    private void Start()
    {
        playerskill = player.GetComponent<PlayerSkill>(); // playerskill.cs를 가져옴
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
            thisSkill = skills[0];
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ShowSkillRange(skills[1]);
            thisSkill = skills[1];
        }

        if (skillRange.activeSelf == true)
        {
            // CheckMouseInCircle 호출
            Vector3Int? checkMouseCell = CheckMouseInCircle();

            if (checkMouseCell.HasValue)
            {
                // 스킬 범위 표시
                if (thisSkill.isTargetCell)
                {
                    thisSkill.ShowRange(checkMouseCell.Value);
                    //Debug.Log($"스킬을 사용할 위치: {checkMouseCell.Value}");

                    // 좌클릭 감지
                    if (Input.GetMouseButton(0))
                    {
                        //Debug.Log($"스킬 사용 위치: {checkMouseCell.Value}");
                        Debug.Log(UI_EnergyBar.Instance.GetPlayerEnergy());

                        if (thisSkill.playerCost <= UI_EnergyBar.Instance.GetPlayerEnergy()) // 스킬코스트가 플레이어 현재의 에너지보다 크다면 
                        {
                            UI_EnergyBar.Instance.DecreaseHealth(thisSkill.playerCost);
                            thisSkill.CastSkill(thisSkill, player, checkMouseCell.Value);
                            skillRange.SetActive(false);
                        }
                    }
                }
                else
                {
                    // 대상 지정 스킬
                    thisSkill.ShowRange(checkMouseCell.Value);

                    if (Input.GetMouseButton(0))
                    {
                        Debug.Log($"대상 지정 스킬 사용: {thisSkill}");
                        //Debug.Log(skillTargetObject.gameObject.name);
                        Debug.Log(UI_EnergyBar.Instance.GetPlayerEnergy());
                        if (thisSkill.playerCost <= UI_EnergyBar.Instance.GetPlayerEnergy()) // 스킬코스트가 플레이어 현재의 에너지보다 크다면 
                        {
                            UI_EnergyBar.Instance.DecreaseHealth(thisSkill.playerCost);
                            thisSkill.CastSkill(thisSkill, player, checkMouseCell.Value);
                            skillRange.SetActive(false);
                        }
                        skillRange.SetActive(false);
                    }
                }
            }
            else
            {
                Debug.Log("스킬 사용 가능한 타일이 없음.");
            }
        }
    }

    private void ShowSkillRange(ActiveSkill skill)
    {
        float skillrange = skill.distance;
        //range만큼 이제 사거리를 표시해줘야 함. -> skill 사용이 끝나면 다시 deactivate 해야함.
        skillRange.GetComponent<CircleRangeSize>().UpdateCircleSize(skillrange);
    }


    private Vector3Int? CheckMouseInCircle()
    {
        // 마우스 위치를 기준으로 Ray 생성
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray);

        bool hitCircle = false; // 마우스가 skillRange에 닿았는지
        bool hitCell = false;   // 마우스가 타일 셀에 닿았는지
        Vector3Int? currentCell = null;

        // Ray가 닿은 모든 오브젝트 확인
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                skillTargetObject = hit.collider.gameObject; // 대상 지정 오브젝트
            }

            if (hit.collider.CompareTag("skillRange"))
            {
                hitCircle = true; // skillRange 범위 안에 있음
            }

            if (hit.collider.CompareTag("Cell"))
            {
                hitCell = true; // 타일맵에 닿았음
                Vector3 worldPosition = hit.point;
                currentCell = tilemap.WorldToCell(worldPosition); // 현재 셀 좌표
            }
        }

        // 마우스가 Circle과 타일(Cell) 모두에 닿아 있는 경우
        if (hitCircle && hitCell)
        {
            lastMouseCell = currentCell; // 마지막 유효 셀 업데이트
            //Debug.Log($"마우스가 Circle과 Cell에 닿음. 현재 셀: {currentCell}");
            return currentCell;
        }

        // 마우스가 Circle에만 닿아 있는 경우
        if (hitCircle && lastMouseCell.HasValue)
        {
            //Debug.Log($"마우스가 Circle에만 닿음. 마지막 유효 셀 반환: {lastMouseCell}");
            return lastMouseCell; // 마지막 유효 셀 유지
        }

        // 마우스가 사거리 밖으로 나갔을 경우
        Debug.Log("마우스가 유효한 타일 범위를 벗어남.");
        return null;
    }



}

