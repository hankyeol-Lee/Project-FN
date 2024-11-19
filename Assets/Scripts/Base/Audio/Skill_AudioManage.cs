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
        if(Input.GetKeyDown(KeyCode.G)) { //Debug용 
            //PlaySkillAudio("sound_MagicBullet");
            PlaySkillAudio("Decay");
        }
        */
    }

    public void PlaySkillAudio(string SkillName) // 매개변수로 skill 이름 (구글 시트에 있슴, 영어로)
    {
        AudioClip SkillClip;
        SkillClip = Resources.Load("Skill_Sounds/" + "sound_" + SkillName) as AudioClip;
        //Debug.Log("Play_SkillSounds");
        //Debug.Log("Skill_Sounds/" + SkillName);
        SkillAudioSource.clip = SkillClip;
        SkillAudioSource.PlayOneShot(SkillClip);
    }
}


