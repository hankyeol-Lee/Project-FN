using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillList // 실제로 쓸 스킬들 목록을 집어넣는 곳.
{
    public class MagicBullet : ActiveSkill
    {
        public MagicBullet(SkillData data) : base(data) {} // initializer
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell)
        {
            if (skillCaster.CompareTag("player"))
            {
                //1. 타겟셀을 
                //Debug.Log($"{skillCaster} 가 공격!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // 대상지정 스킬
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. 타겟셀을 
                Debug.Log($"{skillCaster} 가 공격!");
                //TODO : 스킬 날라가는 메소드 만들기. 공통메소드
            }
        }
    }




}
