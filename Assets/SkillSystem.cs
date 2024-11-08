using GameSkill;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SkillSystem : MonoBehaviour
{
    public GameObject player; // ���⿡�� �÷��̾��� ��ų ��ϵ� ���ð���.
    public Tilemap tilemap;
    public GameObject skillRange;
    private PlayerSkill playerskill;
    public ActiveSkill[] skills;
    public GameObject skillTargetObject; // ������� ��ų�� Ÿ��
    public ActiveSkill thisSkill; // Ű�� ������ ��, � ��ų�� ������ check�ϴ� ��ų�� ����Ű�� ����.

    private void Start()
    {
        playerskill = player.GetComponent<PlayerSkill>(); // playerskill.cs�� ������
        if (playerskill != null) //nullcheck
        {
            skills = playerskill.playerSkills; // �迭 ��ü�� ���� ��������
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShowSkillRange(skills[0]);
            //skills[0];
            //if (skillRange.activeSelf == true) { Debug.Log("�̰� ok"); }
            thisSkill = skills[0]; // 

        }
        if (skillRange.activeSelf == true ) // ��Ÿ��� �����ִµ�, ��Ŭ���� ��������.
        {
            Vector3Int? checkMouseCell = CheckMouseInCircle();

            if (checkMouseCell.HasValue)
            {
                if (thisSkill.isTargetCell)
                {
                    Debug.Log($"��ų�� �� ��ġ�� :{checkMouseCell}");
                    //TODO : 1. ��ų �� ��ġ �ֺ����� ��Ÿ� ǥ��. ��Ÿ��� skill�� �־����.
                    //2. ���� skill�� ĳ�����ؾ���.ĳ�����ϴ� ����? �� �����ϼ�.
                    //thisSkill�� cast�ؾ���.
                    thisSkill.ShowRange(); // ��Ÿ� ǥ�� �޼ҵ� ȣ��
                    if (Input.GetMouseButton(0))
                    {
                        thisSkill.CastSkill(thisSkill, player, checkMouseCell.Value);
                        skillRange.SetActive(false);
                    }
                }
                else
                {
                    // ��������� ������Ʈ���� ��ų �����. skillTargetObject
                    thisSkill.ShowRange();
                    if (Input.GetMouseButton(0))
                    {
                        Debug.Log($"�� ��ų �̸�? : �α׷� ���Ұ� {thisSkill}");
                        thisSkill.CastSkill(thisSkill, player, skillTargetObject); // ������� ��ų ���
                        skillRange.SetActive(true);   
                    }
                }

            }
        }

        /*
        if (skillRange.activeSelf && Input.GetMouseButton(1))
        {
            skillRange.SetActive(false);
        }
        */

    }
    private void ShowSkillRange(ActiveSkill skill)
    {
        float skillrange = skill.distance;
        //range��ŭ ���� ��Ÿ��� ǥ������� ��. -> skill ����� ������ �ٽ� deactivate �ؾ���.
        skillRange.GetComponent<CircleRangeSize>().UpdateCircleSize(skillrange);
    }

    private Vector3Int? CheckMouseInCircle() // ���콺�� ���� ��Ÿ� �ȿ� �ְ�, Ÿ�� �ȿ� �ִٸ� Ÿ���� ��ǥ�� ��ȯ, �׷��� �ʴٸ� null�� ��ȯ.
    {
        // ���콺 ��ġ�� �������� Ray ����
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray);

        bool hitCircle = false;
        bool hitCell = false;
        // Ray�� ���� ��� ������Ʈ Ȯ��
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                skillTargetObject = hit.collider.gameObject;
            }
            // �±� �Ǵ� �̸��� ���� ���� cell�� ����
            if (hit.collider.CompareTag("skillRange"))
            {
                hitCircle = true;
            }
            if (hit.collider.CompareTag("Cell"))
            {
                hitCell = true;
            }
        }
        // �� ������Ʈ�� ��� ��Ҵ��� Ȯ��
        if (hitCircle && hitCell)
        {
            Debug.Log("���콺�� ���� cell�� ��� ��� �ֽ��ϴ�.");
            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Cell"))
                {
                    Vector3 worldPosition = hit.point;
                    Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
                    //Debug.Log($"���� ����ǥ : {cellPosition}");
                    return cellPosition;
                }
            }
        }

        return null;
    }

    
}

