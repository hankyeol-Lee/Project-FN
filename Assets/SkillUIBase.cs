using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.UI;

public class SkillUIBase : MonoBehaviour
{
    public GameObject[] usingSkill;
    public static SkillUIBase Instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance  == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setSkilIcon(int slotIndex, ActiveSkill skillData) // Q스킬 변동시 0, W스킬 변동시 1 ...
    {
        GameObject skillSlot = usingSkill[slotIndex];
        UnityEngine.UI.Image skillSlotImage = skillSlot.GetComponent<UnityEngine.UI.Image>();
        skillSlotImage.sprite = skillData.skillIcon;
    }
    public IEnumerator skillCooltime(int slotIndex, ActiveSkill skillData)
    {
        float skillCooltime = skillData.coolDown;
        float remainTime = (skillCooltime-Time.deltaTime);
        GameObject skillSlot = usingSkill[slotIndex];
        UnityEngine.UI.Image skillSlotImage = skillSlot.GetComponent<UnityEngine.UI.Image>();
        skillSlotImage.fillAmount = remainTime/skillCooltime;
        yield return new WaitForFixedUpdate();

    }
}
