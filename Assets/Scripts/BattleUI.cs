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

    public GameObject[] SkillButton; // ��ų��ư�� ������ ���� â�� ����.    

    private void Start()
    {
        StatusPanel.SetActive(false);
        exitButton.SetActive(false);
    }
    public void StatusOnClick() //���� ��ư Ŭ����
    {
        Debug.Log("���� �� ����");
        HideFirstButtons();
        StatusPanel.SetActive(true);
        exitButton.SetActive(true);
    }
    public void MoveOnClick()
    {
        //�̵� ��ư Ŭ����, 
        Debug.Log("�̵� �� ����");
        HideFirstButtons();
        exitButton.SetActive(true);
    }
    public void SkillOnClick() //��ų ��ư Ŭ����
    {
        Debug.Log("��ų �� ����");
        HideFirstButtons();
        exitButton.SetActive(true);
        foreach (var skill in SkillButton)
        {
            skill.gameObject.SetActive(true);
        }
    }
    public void ItemOnClick() //������ ��ư Ŭ����
    {
        Debug.Log("������ �� ����");
        HideFirstButtons();
        exitButton.SetActive(true);
    }
    public void exitButtonOnClick()
    {
        Debug.Log("�ڷΰ��� ��ư �� ����");
        HideSecondButtons();
        ShowFirstButtons();
        //exitButton.SetActive(false);
    }
    private void ShowFirstButtons()
    {
        Debug.Log("����/�̵�/����/������ �� ����");
        foreach (var button in firstbuttons) 
        { 
            button.gameObject.SetActive(true);
        }
    }
    private void HideFirstButtons()
    {
        Debug.Log("����/�̵�/����/������ �� ������");
        foreach (var button in firstbuttons)
        {
            button.gameObject.SetActive(false);
        }
    }
    private void HideSecondButtons()
    {
        Debug.Log("���Ȼ���â/��ųâ/������â �� ������");
        foreach (var button in secondbuttons)
        {
            button.gameObject.SetActive(false);
        }
    }
    
}
