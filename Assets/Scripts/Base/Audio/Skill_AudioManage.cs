using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_AudioManage : MonoBehaviour
{
    //public AudioClip[] Skill_sounds;
    public AudioSource SkillAudioSource;

    void Awake()
    {
            SkillAudioSource = GetComponent<AudioSource>();
    }

 
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.G)) { //Debug�� 
            //PlaySkillAudio("sound_MagicBullet");
            PlaySkillAudio("Decay");
        }
        */
    }

    public void PlaySkillAudio(string SkillName) // �Ű������� skill �̸� (���� ��Ʈ�� �ֽ�, �����)
    {
        AudioClip SkillClip;
        SkillClip = Resources.Load("Skill_Sounds/" + "sound_" + SkillName) as AudioClip;
        //Debug.Log("Play_SkillSounds");
        //Debug.Log("Skill_Sounds/" + SkillName);
        SkillAudioSource.clip = SkillClip;
        SkillAudioSource.PlayOneShot(SkillClip);
    }
}


