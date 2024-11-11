using System.Collections.Generic;
using UnityEngine;
using GameSkill;

namespace GameSkill
{
    public static class SkillList
    {
        public static readonly Dictionary<string, Skill> SkillDict; // 정적으로 SkillDict란 딕셔너리 생성

        static SkillList()
        {
            SkillDict = new Dictionary<string, Skill>
        {
            { "화염구", new Skill("화염구", "목표 지점에 화염구를 발사해 작은 데미지를 줍니다.", 5f, 2, 4, "화염구 | 데미지 5 | Cost 2 | 범위 : 4칸 | ") },
            { "블리자드", new Skill("블리자드", "목표 지점과 한칸 떨어진 곳에 빙결 마법을 시전해 작은 데미지를 줍니다.", 4f, 2, 8, "블리자드 | 데미지 4 | Cost 2 | 범위 : 8칸") }
        };
        }
    }
}
    
