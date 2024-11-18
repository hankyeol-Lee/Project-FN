using Enemyspace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillList // 실제로 쓸 스킬들 목록을 집어넣는 곳.
{
    public class MagicBullet : ActiveSkill
    {
        public MagicBullet(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Bite : ActiveSkill
    {
        public Bite(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Decay : ActiveSkill
    {
        public Decay(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) 
        {
            Debug.Log("castskill 안");
            //Enemy enemy = skillCaster.GetComponent<Enemy>();
            Debug.Log(skillCaster.name);
            EnemyInstances.enemyDict.TryGetValue(skillCaster.name, out Enemy enemy);
            Debug.Log(enemy);
                //TODO : 플레이어 위치 찾고, 플레이어의 셀에 공격하거나 ㅇㅇ 
            Vector3Int playerCellPos = GameManager.Instance.PlayerWorldToCell(GameManager.Instance.player.transform.position);
            Debug.Log(playerCellPos);
            bool? isfuck = GameManager.Instance.IsTargetOnCell(playerCellPos);
            if (isfuck.HasValue) // 만약에 스킬 범위 안에 있다면.
            {
                Debug.Log("안에 있음?");
                float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient,useSkill.skilltype,enemy.returnADAP(useSkill.skilltype));
                Debug.Log(initdamage);
                // 플레이어에게 데미지 주는 함수.
                GameManager.Instance.player.GetComponent<PlayerStatus>().PlayerGetDamage(initdamage,skilltype);
            }
        }   
    }

    public class ManaDrain : ActiveSkill
    {
        public ManaDrain(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Smash : ActiveSkill
    {
        public Smash(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Harden : ActiveSkill
    {
        public Harden(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Ambush : ActiveSkill
    {
        public Ambush(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class VenomousFang : ActiveSkill
    {
        public VenomousFang(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Aftershock : ActiveSkill
    {
        public Aftershock(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class GhostlyGrasp : ActiveSkill
    {
        public GhostlyGrasp(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Fireball : ActiveSkill
    {
        public Fireball(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Rage : ActiveSkill
    {
        public Rage(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Flame : ActiveSkill
    {
        public Flame(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class IronShield : ActiveSkill
    {
        public IronShield(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Sweep : ActiveSkill
    {
        public Sweep(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class IceArrow : ActiveSkill
    {
        public IceArrow(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class CloakAndReveal : ActiveSkill
    {
        public CloakAndReveal(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class LifeTransfusion : ActiveSkill
    {
        public LifeTransfusion(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class GreatMagicShield : ActiveSkill
    {
        public GreatMagicShield(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Vampirism : ActiveSkill
    {
        public Vampirism(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class RapidStrike : ActiveSkill
    {
        public RapidStrike(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Tear : ActiveSkill
    {
        public Tear(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Scream : ActiveSkill
    {
        public Scream(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class AcidicBody : ActiveSkill
    {
        public AcidicBody(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class UnstableMixture : ActiveSkill
    {
        public UnstableMixture(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class FlameCharge : ActiveSkill
    {
        public FlameCharge(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class FlameClaws : ActiveSkill
    {
        public FlameClaws(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Aiming : ActiveSkill
    {
        public Aiming(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Calcification : ActiveSkill
    {
        public Calcification(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Intimidate : ActiveSkill
    {
        public Intimidate(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Plunder : ActiveSkill
    {
        public Plunder(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }

    }

    public class Ignite : ActiveSkill
    {
        public Ignite(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class FlamePillar : ActiveSkill
    {
        public FlamePillar(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Possession : ActiveSkill
    {
        public Possession(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class CursedSword : ActiveSkill
    {
        public CursedSword(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Blizzard : ActiveSkill
    {
        public Blizzard(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Frostbite : ActiveSkill
    {
        public Frostbite(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class FlameBreath : ActiveSkill
    {
        public FlameBreath(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class ForwardThrust : ActiveSkill
    {
        public ForwardThrust(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class SpearOfBlood : ActiveSkill
    {
        public SpearOfBlood(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class MistForm : ActiveSkill
    {
        public MistForm(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class SlashAndCut : ActiveSkill
    {
        public SlashAndCut(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Howl : ActiveSkill
    {
        public Howl(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Rake : ActiveSkill
    {
        public Rake(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class EarthOfFire : ActiveSkill
    {
        public EarthOfFire(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class WeaponOfFire : ActiveSkill
    {
        public WeaponOfFire(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Volcano : ActiveSkill
    {
        public Volcano(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Crossfire : ActiveSkill
    {
        public Crossfire(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class ExecutionersGreatSword : ActiveSkill
    {
        public ExecutionersGreatSword(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }

    public class Execution : ActiveSkill
    {
        public Execution(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) { }
    }
}
