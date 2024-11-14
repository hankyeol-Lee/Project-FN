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
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Bite : ActiveSkill
    {
        public Bite(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Decay : ActiveSkill
    {
        public Decay(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class ManaDrain : ActiveSkill
    {
        public ManaDrain(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Smash : ActiveSkill
    {
        public Smash(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Harden : ActiveSkill
    {
        public Harden(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Ambush : ActiveSkill
    {
        public Ambush(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class VenomousFang : ActiveSkill
    {
        public VenomousFang(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Aftershock : ActiveSkill
    {
        public Aftershock(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class GhostlyGrasp : ActiveSkill
    {
        public GhostlyGrasp(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Fireball : ActiveSkill
    {
        public Fireball(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Rage : ActiveSkill
    {
        public Rage(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Flame : ActiveSkill
    {
        public Flame(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class IronShield : ActiveSkill
    {
        public IronShield(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Sweep : ActiveSkill
    {
        public Sweep(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class IceArrow : ActiveSkill
    {
        public IceArrow(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class CloakAndReveal : ActiveSkill
    {
        public CloakAndReveal(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class LifeTransfusion : ActiveSkill
    {
        public LifeTransfusion(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class GreatMagicShield : ActiveSkill
    {
        public GreatMagicShield(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Vampirism : ActiveSkill
    {
        public Vampirism(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class RapidStrike : ActiveSkill
    {
        public RapidStrike(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Tear : ActiveSkill
    {
        public Tear(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Scream : ActiveSkill
    {
        public Scream(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class AcidicBody : ActiveSkill
    {
        public AcidicBody(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class UnstableMixture : ActiveSkill
    {
        public UnstableMixture(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class FlameCharge : ActiveSkill
    {
        public FlameCharge(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class FlameClaws : ActiveSkill
    {
        public FlameClaws(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Aiming : ActiveSkill
    {
        public Aiming(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Calcification : ActiveSkill
    {
        public Calcification(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Intimidate : ActiveSkill
    {
        public Intimidate(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Plunder : ActiveSkill
    {
        public Plunder(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Ignite : ActiveSkill
    {
        public Ignite(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class FlamePillar : ActiveSkill
    {
        public FlamePillar(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Possession : ActiveSkill
    {
        public Possession(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class CursedSword : ActiveSkill
    {
        public CursedSword(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Blizzard : ActiveSkill
    {
        public Blizzard(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Frostbite : ActiveSkill
    {
        public Frostbite(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class FlameBreath : ActiveSkill
    {
        public FlameBreath(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class ForwardThrust : ActiveSkill
    {
        public ForwardThrust(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class SpearOfBlood : ActiveSkill
    {
        public SpearOfBlood(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class MistForm : ActiveSkill
    {
        public MistForm(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class SlashAndCut : ActiveSkill
    {
        public SlashAndCut(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Howl : ActiveSkill
    {
        public Howl(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Rake : ActiveSkill
    {
        public Rake(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class EarthOfFire : ActiveSkill
    {
        public EarthOfFire(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class WeaponOfFire : ActiveSkill
    {
        public WeaponOfFire(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Volcano : ActiveSkill
    {
        public Volcano(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Crossfire : ActiveSkill
    {
        public Crossfire(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class ExecutionersGreatSword : ActiveSkill
    {
        public ExecutionersGreatSword(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }

    public class Execution : ActiveSkill
    {
        public Execution(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill) { }
    }
}
