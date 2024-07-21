using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    public GameObject[] firstbuttons;
    public GameObject[] secondbuttons;
    public GameObject StatusPanel;
    public GameObject exitButton;

    public GameObject[] SkillButton; // 스킬버튼을 누르면 나올 창들 모음.    

    private void Start()
    {
        StatusPanel.SetActive(false);
        exitButton.SetActive(false);
    }
    public void StatusOnClick() //스탯 버튼 클릭시
    {
        Debug.Log("스탯 잘 눌림");
        HideFirstButtons();
        StatusPanel.SetActive(true);
        exitButton.SetActive(true);
    }
    public void MoveOnClick()
    {
        //이동 버튼 클릭시, 
        Debug.Log("이동 잘 눌림");
        HideFirstButtons();
        exitButton.SetActive(true);
    }
    public void SkillOnClick() //스킬 버튼 클릭시
    {
        Debug.Log("스킬 잘 눌림");
        HideFirstButtons();
        exitButton.SetActive(true);
        foreach (var skill in SkillButton)
        {
            skill.gameObject.SetActive(true);
        }
    }
    public void ItemOnClick() //아이템 버튼 클릭시
    {
        Debug.Log("아이템 잘 눌림");
        HideFirstButtons();
        exitButton.SetActive(true);
    }
    public void exitButtonOnClick()
    {
        Debug.Log("뒤로가기 버튼 잘 눌림");
        HideSecondButtons();
        ShowFirstButtons();
        //exitButton.SetActive(false);
    }
    private void ShowFirstButtons()
    {
        Debug.Log("스탯/이동/공격/아이템 잘 나옴");
        foreach (var button in firstbuttons) 
        { 
            button.gameObject.SetActive(true);
        }
    }
    private void HideFirstButtons()
    {
        Debug.Log("스탯/이동/공격/아이템 잘 지워짐");
        foreach (var button in firstbuttons)
        {
            button.gameObject.SetActive(false);
        }
    }
    private void HideSecondButtons()
    {
        Debug.Log("스탯상태창/스킬창/아이템창 잘 지워짐");
        foreach (var button in secondbuttons)
        {
            button.gameObject.SetActive(false);
        }
    }
    
}
