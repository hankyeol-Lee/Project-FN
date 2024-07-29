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

    public GameObject[] SkillButton; // 스킬버튼을 누르면 나올 창들 모음.    

    private void Start()
    {
        HideSecondButtons();
    }
    public void StatusOnClick() //스탯 버튼 클릭시
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
            firstbuttons[0].GetComponent<Status_Anim_OnEnable>().OnStatusClick_Move(isClicked); //이 객체의 OnSkillClick_Move() 함수를 실행
            isClicked = true;
        }
        else
        {
            HideSecondButtons();
            ShowFirstButtons();
            isClicked = false;
        }
        
    }

    public void SkillOnClick() //스킬 버튼 클릭시
    {
        if (!isClicked)
        {
            //Debug.Log(isClicked);
            HideFirstButtons();
            foreach (var skill in SkillButton)
            {
                skill.gameObject.SetActive(true);
            }
            firstbuttons[1].gameObject.SetActive(true); //이 코드를 수행한 객체를 활성화
            firstbuttons[1].GetComponent<Skill_Anim_OnEnable>().OnSkillClick_Move(isClicked); //이 객체의 OnSkillClick_Move() 함수를 실행
            isClicked = true;
            //isClicked = false; // 눌렸으니 눌렸다고 ㅇㅇ 
        }
        else
        {
            firstbuttons[1].GetComponent<Skill_Anim_OnEnable>().OnSkillClick_Move(isClicked); //이 객체의 OnSkillClick_Move() 함수를 실행
            HideSecondButtons();
            ShowFirstButtons();
            isClicked = false;
        }

    }
    public void ItemOnClick() //아이템 버튼 클릭시
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
            firstbuttons[2].gameObject.SetActive(true); //이 코드를 수행한 객체를 활성화
            firstbuttons[2].GetComponent<Item_Anim_OnEnable>().OnItemClick_Move(isClicked); //이 객체의 OnSkillClick_Move() 함수를 실행
            isClicked = true;
        }
        else
        {
            firstbuttons[2].GetComponent<Item_Anim_OnEnable>().OnItemClick_Move(isClicked); //이 객체의 OnSkillClick_Move() 함수를 실행
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
