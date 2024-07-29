using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    public GameObject[] firstbuttons;
    public GameObject[] secondbuttons;
    public GameObject StatusPanel;

    public bool isClicked = false;

    public GameObject[] SkillButton; // ��ų��ư�� ������ ���� â�� ����.    

    private void Start()
    {
        HideSecondButtons();
    }
    public void StatusOnClick() //���� ��ư Ŭ����
    {
        if (!isClicked)
        {
            HideFirstButtons();
            /* 
             foreach (var status in statusButton)
            {
                status.gameObject.SetActive(true);
            }
             
             */
            firstbuttons[0].gameObject.SetActive(true);
            firstbuttons[0].GetComponent<Status_Anim_OnEnable>().OnStatusClick_Move(isClicked); //�� ��ü�� OnSkillClick_Move() �Լ��� ����
            isClicked = true;
        }
        else
        {
            HideSecondButtons();
            ShowFirstButtons();
            isClicked = false;
        }
        
    }

    public void SkillOnClick() //��ų ��ư Ŭ����
    {
        if (!isClicked)
        {
            //Debug.Log(isClicked);
            HideFirstButtons();
            foreach (var skill in SkillButton)
            {
                skill.gameObject.SetActive(true);
            }
            firstbuttons[1].gameObject.SetActive(true); //�� �ڵ带 ������ ��ü�� Ȱ��ȭ
            firstbuttons[1].GetComponent<Skill_Anim_OnEnable>().OnSkillClick_Move(isClicked); //�� ��ü�� OnSkillClick_Move() �Լ��� ����
            isClicked = true;
            //isClicked = false; // �������� ���ȴٰ� ���� 
        }
        else
        {
            firstbuttons[1].GetComponent<Skill_Anim_OnEnable>().OnSkillClick_Move(isClicked); //�� ��ü�� OnSkillClick_Move() �Լ��� ����
            HideSecondButtons();
            ShowFirstButtons();
            isClicked = false;
        }

    }
    public void ItemOnClick() //������ ��ư Ŭ����
    {
        Debug.Log(isClicked);

        if (!isClicked)
        {
            //Debug.Log(isClicked);
            HideFirstButtons();
            foreach (var skill in SkillButton)
            {
                skill.gameObject.SetActive(true);
            }
            firstbuttons[2].gameObject.SetActive(true); //�� �ڵ带 ������ ��ü�� Ȱ��ȭ
            firstbuttons[2].GetComponent<Item_Anim_OnEnable>().OnItemClick_Move(isClicked); //�� ��ü�� OnSkillClick_Move() �Լ��� ����
            isClicked = true;
        }
        else
        {
            firstbuttons[2].GetComponent<Item_Anim_OnEnable>().OnItemClick_Move(isClicked); //�� ��ü�� OnSkillClick_Move() �Լ��� ����
            HideSecondButtons();
            ShowFirstButtons();
            isClicked = false;
        }
    }
    public void exitButtonOnClick()
    {

        HideSecondButtons();
        ShowFirstButtons();
        //exitButton.SetActive(false);
    }
    private void ShowFirstButtons()
    {

        foreach (var button in firstbuttons)
        {
            button.gameObject.SetActive(true);
        }
        //isClicked = false;
    }
    private void HideFirstButtons()
    {

        foreach (var button in firstbuttons)
        {
            button.gameObject.SetActive(false);
        }
        //isClicked = false;
    }
    private void HideSecondButtons()
    {

        foreach (var button in secondbuttons)
        {
            button.gameObject.SetActive(false);
        }
    }

}
