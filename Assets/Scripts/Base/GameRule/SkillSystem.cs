using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SkillSystem : MonoBehaviour
{
    public GameObject player; // ���⿡�� �÷��̾��� ��ų ��ϵ�?���ð���.
    public Tilemap tilemap;
    public GameObject skillRange; // ��Ÿ�?
    private PlayerSkill playerskill;
    public ActiveSkill[] skills;
    public GameObject skillTargetObject; // �������?��ų�� Ÿ��
    public ActiveSkill thisSkill; // Ű�� ������ ��, � ��ų�� ������ check�ϴ� ��ų�� ����Ű�� ����.

    private Vector3Int? lastMouseCell = null; // ���������� �ӹ����� �� ��ǥ ����

    public static SkillSystem Instance;

    private void Awake()
    {
        if (Instance  == null)
        {
            Instance = this;
        }
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
            thisSkill = skills[0];
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ShowSkillRange(skills[1]);
            thisSkill = skills[1];
        }

        if (skillRange.activeSelf == true)
        {
            // CheckMouseInCircle ȣ��
            Vector3Int? checkMouseCell = CheckMouseInCircle();

            if (checkMouseCell.HasValue)
            {
                //Debug.Log($"{ checkMouseCell.Value} ��ų ���!!");
                // ��ų ���� ǥ��
                if (thisSkill.isTargetCell)
                {
                    thisSkill.ShowRange(checkMouseCell.Value);
                    //Debug.Log($"��ų�� �����?��ġ: {checkMouseCell.Value}");

                    // ��Ŭ�� ����
                    if (Input.GetMouseButton(0))
                    {
                        //Debug.Log($"��ų ���?��ġ: {checkMouseCell.Value}");
                        //Debug.Log(UI_EnergyBar.Instance.GetPlayerEnergy());

                        if (thisSkill.playerCost <= UI_EnergyBar.Instance.GetPlayerEnergy()) // ��ų�ڽ�Ʈ�� �÷��̾� ������ ���������� ũ�ٸ� 
                        {
                            UI_EnergyBar.Instance.DecreaseHealth(thisSkill.playerCost);
                            ShowSkillAnimation(thisSkill.skillName, player.transform.position, checkMouseCell.Value);
                            thisSkill.CastSkill(thisSkill, player, checkMouseCell.Value);
                            skillRange.SetActive(false);
                        }
                    }
                }
                else
                    // ���?���� ��ų
                    thisSkill.ShowRange(checkMouseCell.Value);
                    if (Input.GetMouseButton(0))
                    {
                        Debug.Log(skillTargetObject.gameObject.name);
                        //Debug.Log(UI_EnergyBar.Instance.GetPlayerEnergy());
                        if (thisSkill.playerCost <= UI_EnergyBar.Instance.GetPlayerEnergy()) // ��ų�ڽ�Ʈ�� �÷��̾� ������ ���������� ũ�ٸ� 
                        {
                            UI_EnergyBar.Instance.DecreaseHealth(thisSkill.playerCost);
                            ShowSkillAnimation(thisSkill.skillName, player.transform.position, skillTargetObject.gameObject.transform.position);
                            thisSkill.CastSkill(thisSkill, player, skillTargetObject);
                            skillRange.SetActive(false);
                        }
                        //�ڽ�Ʈ ���� ���?�����ؾ���
                        //skillRange.SetActive(false);
                    }
                }
            }
        }
    }

    private void ShowSkillRange(ActiveSkill skill)
    {
        float skillrange = skill.distance;
        //range��ŭ ���� ��Ÿ���?ǥ�������?��. -> skill �����?������ �ٽ� deactivate �ؾ���.
        skillRange.GetComponent<CircleRangeSize>().UpdateCircleSize(skillrange);
    }


    private Vector3Int? CheckMouseInCircle()
    {
        // ���콺 ��ġ�� �������� Ray ����
        skillTargetObject = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray);

        bool hitCircle = false; // ���콺�� skillRange�� ��Ҵ���?
        bool hitCell = false;   // ���콺�� Ÿ�� ���� ��Ҵ���?
        Vector3Int? currentCell = null;

        // Ray�� ���� ���?������Ʈ Ȯ��
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                skillTargetObject = hit.collider.gameObject; // ���?���� ������Ʈ
            }

            if (hit.collider.CompareTag("skillRange"))
            {
                hitCircle = true; // skillRange ���� �ȿ� ����
            }

            if (hit.collider.CompareTag("Cell"))
            {
                hitCell = true; // Ÿ�ϸʿ� �����?
                Vector3 worldPosition = hit.point;
                currentCell = tilemap.WorldToCell(worldPosition); // ���� �� ��ǥ
            }
        }

        // ���콺�� Circle�� Ÿ��(Cell) ��ο�?���?�ִ� ���?
        if (hitCircle && hitCell)
        {
            lastMouseCell = currentCell; // ������ ��ȿ �� ������Ʈ
            //Debug.Log($"���콺�� Circle�� Cell�� ����. ���� ��: {currentCell}");
            return currentCell;
            
        }

        // ���콺�� Circle���� ���?�ִ� ���?
        if (hitCircle && lastMouseCell.HasValue)
        {
            //Debug.Log($"���콺�� Circle���� ����. ������ ��ȿ �� ��ȯ: {lastMouseCell}");
            //Debug.Log($"{lastMouseCell} �����ͤ���");
            return lastMouseCell; // ������ ��ȿ �� ����
        }

        // ���콺�� ��Ÿ�?������ ������ ���?
        return null;
    }
    public void ShowSkillAnimation(string skillName, Vector3 Start, Vector3 End)
    {
        GameObject skillPrefab = Resources.Load<GameObject>($"Prefab/SkillEffect/{skillName}");
        if (skillPrefab != null)
        {
            GameObject skillAnimationInstance = Instantiate(skillPrefab, Start, Quaternion.identity);

            // ���� ���� ��Ʈ: �ڷ�ƾ ȣ��
            StartCoroutine(MoveSkillAnimation(skillAnimationInstance, Start, End, 0.3f)); 
        }
    }

    private IEnumerator MoveSkillAnimation(GameObject skillInstance, Vector3 start, Vector3 end, float duration)
    {
        float elapsedTime = 0f;

        // �̵� ó��
        while (elapsedTime < duration)
        {
            if (skillInstance == null) yield break; // ������Ʈ�� ������ ���?�ڷ�ƾ ����
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration); // 0���� 1������ ���� ����
            skillInstance.transform.position = Vector3.Lerp(start, end, t); // ���� ����
            yield return null; // ���� �����ӱ��� ���?
        }

        // �̵� �Ϸ� �� ������Ʈ ����
        if (skillInstance != null)
            Destroy(skillInstance);
    }
    public void SetTilemap(Tilemap currentTilemap)
    {
        tilemap = currentTilemap;
    }

}

