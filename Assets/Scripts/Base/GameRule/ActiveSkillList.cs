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

    public class Bite : ActiveSkill
    {
        public Bite(SkillData data) : base(data) { } // initializer
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


    public class Decay : ActiveSkill
    {
        public Decay(SkillData data) : base(data) { } // initializer
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

    public class ManaDrain : ActiveSkill
    {
        public ManaDrain(SkillData data) : base(data) { } // initializer
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

    public class Smash : ActiveSkill
    {
        public Smash(SkillData data) : base(data) { } // initializer
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
    public class Harden : ActiveSkill
    {
        public Harden(SkillData data) : base(data) { } // initializer
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
    public class Ambush : ActiveSkill
    {
        public Ambush(SkillData data) : base(data) { } // initializer
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
    public class VenomousFang : ActiveSkill
    {
        public VenomousFang(SkillData data) : base(data) { } // initializer
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
    public class Aftershock : ActiveSkill
    {
        public Aftershock(SkillData data) : base(data) { } // initializer
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
    public class GhostlyGrasp : ActiveSkill
    {
        public GhostlyGrasp(SkillData data) : base(data) { } // initializer
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
    public class Fireball : ActiveSkill
    {
        public Fireball(SkillData data) : base(data) { } // initializer
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
    public class Rage : ActiveSkill
    {
        public Rage(SkillData data) : base(data) { } // initializer
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
    public class Flame : ActiveSkill
    {
        public Flame(SkillData data) : base(data) { } // initializer
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
    public class IronShield : ActiveSkill
    {
        public IronShield(SkillData data) : base(data) { } // initializer
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
    public class Sweep : ActiveSkill
    {
        public Sweep(SkillData data) : base(data) { } // initializer
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
    public class IceArrow : ActiveSkill
    {
        public IceArrow(SkillData data) : base(data) { } // initializer
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
    public class CloakAndReveal : ActiveSkill
    {
        public CloakAndReveal(SkillData data) : base(data) { } // initializer
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
    public class LifeTransfusion : ActiveSkill
    {
        public LifeTransfusion(SkillData data) : base(data) { } // initializer
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
    public class GreatMagicShield : ActiveSkill
    {
        public GreatMagicShield(SkillData data) : base(data) { } // initializer
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
    public class Vampirism : ActiveSkill
    {
        public Vampirism(SkillData data) : base(data) { } // initializer
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
    public class RapidStrike : ActiveSkill
    {
        public RapidStrike(SkillData data) : base(data) { } // initializer
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
    public class Tear : ActiveSkill
    {
        public Tear(SkillData data) : base(data) { } // initializer
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
    public class Scream : ActiveSkill
    {
        public Scream(SkillData data) : base(data) { } // initializer
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
    public class AcidicBody : ActiveSkill
    {
        public AcidicBody(SkillData data) : base(data) { } // initializer
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
    public class UnstableMixture : ActiveSkill
    {
        public UnstableMixture(SkillData data) : base(data) { } // initializer
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
    public class FlameCharge : ActiveSkill
    {
        public FlameCharge(SkillData data) : base(data) { } // initializer
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
    public class FlameClaws : ActiveSkill
    {
        public FlameClaws(SkillData data) : base(data) { } // initializer
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
    public class Aiming : ActiveSkill
    {
        public Aiming(SkillData data) : base(data) { } // initializer
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
    public class Calcification : ActiveSkill
    {
        public Calcification(SkillData data) : base(data) { } // initializer
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
    public class Intimidate : ActiveSkill
    {
        public Intimidate(SkillData data) : base(data) { } // initializer
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
    public class Plunder : ActiveSkill
    {
        public Plunder(SkillData data) : base(data) { } // initializer
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
    public class Ignite : ActiveSkill
    {
        public Ignite(SkillData data) : base(data) { } // initializer
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
    public class FlamePillar : ActiveSkill
    {
        public FlamePillar(SkillData data) : base(data) { } // initializer
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
    public class Possession : ActiveSkill
    {
        public Possession(SkillData data) : base(data) { } // initializer
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
    public class CursedSword : ActiveSkill
    {
        public CursedSword(SkillData data) : base(data) { } // initializer
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
    public class Blizzard : ActiveSkill
    {
        public Blizzard(SkillData data) : base(data) { } // initializer
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
    public class Frostbite : ActiveSkill
    {
        public Frostbite(SkillData data) : base(data) { } // initializer
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
    public class FlameBreath : ActiveSkill
    {
        public FlameBreath(SkillData data) : base(data) { } // initializer
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
    public class ForwardThrust : ActiveSkill
    {
        public ForwardThrust(SkillData data) : base(data) { } // initializer
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
    public class SpearOfBlood : ActiveSkill
    {
        public SpearOfBlood(SkillData data) : base(data) { } // initializer
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
    public class MistForm : ActiveSkill
    {
        public MistForm(SkillData data) : base(data) { } // initializer
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
    public class SlashAndCut : ActiveSkill
    {
        public SlashAndCut(SkillData data) : base(data) { } // initializer
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
    public class Howl : ActiveSkill
    {
        public Howl(SkillData data) : base(data) { } // initializer
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
    public class Rake : ActiveSkill
    {
        public Rake(SkillData data) : base(data) { } // initializer
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
    public class EarthOfFire : ActiveSkill
    {
        public EarthOfFire(SkillData data) : base(data) { } // initializer
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
    public class WeaponOfFire : ActiveSkill
    {
        public WeaponOfFire(SkillData data) : base(data) { } // initializer
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
    public class Volcano : ActiveSkill
    {
        public Volcano(SkillData data) : base(data) { } // initializer
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
    public class Crossfire : ActiveSkill
    {
        public Crossfire(SkillData data) : base(data) { } // initializer
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
    public class ExecutionersGreatSword : ActiveSkill
    {
        public ExecutionersGreatSword(SkillData data) : base(data) { } // initializer
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
    public class Execution : ActiveSkill
    {
        public Execution(SkillData data) : base(data) { } // initializer
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
