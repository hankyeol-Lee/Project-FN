using Enemyspace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillList // ������ �� ��ų�� ����� ����ִ� ��.
{
    public class MagicBullet : ActiveSkill
    {
        public MagicBullet(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) 
        {
            //�ؾ��� �� : ��ų Ÿ�� ������Ʈ�� instance�� dictionary���� ã�Ƽ� 
            //initdamage�� ��� �� 
            //�� ������Ʈ(���ʹ�)�� GetDamage�Լ��� ���.
            //Debug.Log("�̰žƳ�?");
            EnemyInstances.enemyDict.TryGetValue(skillTarget.name, out Enemy enemy);
            //Debug.Log(skillTarget.name);
            Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
            SkillSystem.Instance.ShowSkillAnimation(useSkill.skillName, skillCaster.transform.position, skillTarget.transform.position);
            float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, GameManager.Instance.player.GetComponent<PlayerStatus>().returnADAP(useSkill.skilltype));
            enemy.TakeDamage(skillTarget.transform,initdamage,useSkill.skilltype);
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) 
        {
            EnemyInstances.enemyDict.TryGetValue(skillCaster.name, out Enemy enemy); // 1. enemy ��ü�� ��ų �������� ������ enemyDict���� �޾ƿ�.(����)
            //Debug.Log($"useskill : {useSkill}, enemy : {enemy}, enemy returnadap : {enemy.returnADAP(useSkill.skilltype)}");
            float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, enemy.returnADAP(useSkill.skilltype)); // ��ų��� * ���ݷ�(Ȥ�� AP)
            Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
            GameManager.Instance.player.GetComponent<PlayerStatus>().PlayerGetDamage(initdamage, skilltype); // �÷��̾�� ���� �������� �ִ� �ڵ�
            //Debug.Log($"{skillCaster.name}���԰��ݴ��޴ٴ°��� {useSkill.skillName} {skillCaster.transform.position}, {GameManager.Instance.player.transform.position}");
            SkillSystem.Instance.ShowSkillAnimation(useSkill.skillName, skillCaster.transform.position, GameManager.Instance.player.transform.position);
        }
    }

    public class Bite : ActiveSkill
    {
        public Bite(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) 
        {
            EnemyInstances.enemyDict.TryGetValue(skillTarget.name, out Enemy enemy);
            Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
            SkillSystem.Instance.ShowSkillAnimation(useSkill.skillName, skillCaster.transform.position, skillTarget.transform.position);
            float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, GameManager.Instance.player.GetComponent<PlayerStatus>().returnADAP(useSkill.skilltype));
            enemy.TakeDamage(skillTarget.transform, initdamage, useSkill.skilltype);
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) // enemy�� ����ϴ� skill �����ε�.
        {
            //������� ��ų�� ���
            EnemyInstances.enemyDict.TryGetValue(skillCaster.name, out Enemy enemy); // 1. enemy ��ü�� ��ų �������� ������ enemyDict���� �޾ƿ�.(����)
            //Debug.Log($"useskill : {useSkill}, enemy : {enemy}, enemy returnadap : {enemy.returnADAP(useSkill.skilltype)}");
            float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, enemy.returnADAP(useSkill.skilltype)); // ��ų��� * ���ݷ�(Ȥ�� AP)
            Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
            GameManager.Instance.player.GetComponent<PlayerStatus>().PlayerGetDamage(initdamage, skilltype); // �÷��̾�� ���� �������� �ִ� �ڵ�
            //Debug.Log($"{skillCaster.name}���԰��ݴ��޴ٴ°��� {useSkill.skillName} {skillCaster.transform.position}, {GameManager.Instance.player.transform.position}");
            SkillSystem.Instance.ShowSkillAnimation(useSkill.skillName, skillCaster.transform.position, GameManager.Instance.player.transform.position);
        }
    }

    public class Decay : ActiveSkill
    {
        public Decay(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) 
        {
            Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
            foreach (var inenemy in CheckRangeEnemy(targetCell))
            {
                EnemyInstances.enemyDict.TryGetValue(inenemy.name, out Enemy enemy);
                //Debug.Log($"{inenemy.name}�� ������ ����");
                float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, GameManager.Instance.player.GetComponent<PlayerStatus>().returnADAP(useSkill.skilltype));
                enemy.TakeDamage(inenemy.transform, initdamage, useSkill.skilltype);
                //Debug.Log($"{inenemy.name}�� HP : {enemy.HP}, ���� ���� : {initdamage}");
                SkillSystem.Instance.ShowSkillAnimation(useSkill.skillName, skillCaster.transform.position, inenemy.transform.position);
            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) 
        {
            // �� Ÿ����
            EnemyInstances.enemyDict.TryGetValue(skillCaster.name, out Enemy enemy);
            Vector3Int playerCellPos = GameManager.Instance.PlayerWorldToCell(GameManager.Instance.player.transform.position);
            bool? isfuck = GameManager.Instance.IsTargetOnCell(playerCellPos); // �� �� ���� �÷��̾ �ִٸ�(�÷��̾ �ִ� �� ��ġ == IstargetOnCell())
            if (isfuck.HasValue) // ���࿡ ��ų ���� �ȿ� �ִٸ�.
            {
                float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient,useSkill.skilltype,enemy.returnADAP(useSkill.skilltype));
                Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
                // �÷��̾�� ������ �ִ� �Լ�.
                GameManager.Instance.player.GetComponent<PlayerStatus>().PlayerGetDamage(initdamage,skilltype);
                //Debug.Log($"{skillCaster.name}���԰��ݴ��޴ٴ°��� {useSkill.skillName} {skillCaster.transform.position}, {GameManager.Instance.player.GetComponent<Transform>().position}");
                SkillSystem.Instance.ShowSkillAnimation(useSkill.skillName, skillCaster.transform.position, GameManager.Instance.player.transform.position);
            }
        }   
    }

    public class ManaDrain : ActiveSkill
    {
        public ManaDrain(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) 
        {
            foreach (var inenemy in CheckRangeEnemy(targetCell))
            {
                EnemyInstances.enemyDict.TryGetValue(inenemy.name, out Enemy enemy);
                //Debug.Log($"{inenemy.name}�� ������ ����");
                Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
                float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, GameManager.Instance.player.GetComponent<PlayerStatus>().returnADAP(useSkill.skilltype));
                enemy.TakeDamage(inenemy.transform, initdamage, useSkill.skilltype);
                //Debug.Log($"{inenemy.name}�� HP : {enemy.HP}, ���� ���� : {initdamage}");
                SkillSystem.Instance.ShowSkillAnimation(useSkill.skillName, skillCaster.transform.position, inenemy.transform.position);
            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) 
        {
            EnemyInstances.enemyDict.TryGetValue(skillCaster.name, out Enemy enemy);
            Vector3Int playerCellPos = GameManager.Instance.PlayerWorldToCell(GameManager.Instance.player.transform.position);
            bool? isfuck = GameManager.Instance.IsTargetOnCell(playerCellPos); // �� �� ���� �÷��̾ �ִٸ�(�÷��̾ �ִ� �� ��ġ == IstargetOnCell())
            if (isfuck.HasValue) // ���࿡ ��ų ���� �ȿ� �ִٸ�.
            {
                float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, enemy.returnADAP(useSkill.skilltype));
                Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
                // �÷��̾�� ������ �ִ� �Լ�.
                GameManager.Instance.player.GetComponent<PlayerStatus>().PlayerGetDamage(initdamage, skilltype);
                //Debug.Log($"{skillCaster.name}���԰��ݴ��޴ٴ°��� {useSkill.skillName} {skillCaster.transform.position}, {GameManager.Instance.player.GetComponent<Transform>().position}");
                SkillSystem.Instance.ShowSkillAnimation(useSkill.skillName, skillCaster.transform.position, GameManager.Instance.player.transform.position);
            }
        }
    }

    public class Smash : ActiveSkill
    {
        public Smash(SkillData data) : base(data) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) 
        {
            EnemyInstances.enemyDict.TryGetValue(skillTarget.name, out Enemy enemy);
            float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, GameManager.Instance.player.GetComponent<PlayerStatus>().returnADAP(useSkill.skilltype));
            Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
            SkillSystem.Instance.ShowSkillAnimation(useSkill.skillName, skillCaster.transform.position, skillTarget.transform.position);
            enemy.TakeDamage(skillTarget.transform, initdamage, useSkill.skilltype);
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) 
        {
            //������� ��ų�� ���
            EnemyInstances.enemyDict.TryGetValue(skillCaster.name, out Enemy enemy); // 1. enemy ��ü�� ��ų �������� ������ enemyDict���� �޾ƿ�.(����)
            //Debug.Log($"useskill : {useSkill}, enemy : {enemy}, enemy returnadap : {enemy.returnADAP(useSkill.skilltype)}");
            float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, enemy.returnADAP(useSkill.skilltype)); // ��ų��� * ���ݷ�(Ȥ�� AP)
            Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
            GameManager.Instance.player.GetComponent<PlayerStatus>().PlayerGetDamage(initdamage, skilltype); // �÷��̾�� ���� �������� �ִ� �ڵ�
            //Debug.Log($"{skillCaster.name}���԰��ݴ��޴ٴ°��� {useSkill.skillName} {skillCaster.transform.position}, {GameManager.Instance.player.transform.position}");
            SkillSystem.Instance.ShowSkillAnimation(useSkill.skillName, skillCaster.transform.position, GameManager.Instance.player.transform.position);
        }
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
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) 
        {
            EnemyInstances.enemyDict.TryGetValue(skillTarget.name, out Enemy enemy);
            Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
            SkillSystem.Instance.ShowSkillAnimation(useSkill.skillName, skillCaster.transform.position, skillTarget.transform.position);
            float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, GameManager.Instance.player.GetComponent<PlayerStatus>().returnADAP(useSkill.skilltype));
            //�̱��� TakeDotDamage
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) 
        {
            EnemyInstances.enemyDict.TryGetValue(skillCaster.name, out Enemy enemy); 
            float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, enemy.returnADAP(useSkill.skilltype)); 
            Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
            //�̱��� TakeDotDamage
            //�̱��� TakeDotDamage
        }
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
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) 
        {
            EnemyInstances.enemyDict.TryGetValue(skillTarget.name, out Enemy enemy);
            Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
            float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, GameManager.Instance.player.GetComponent<PlayerStatus>().returnADAP(useSkill.skilltype));
            enemy.TakeDamage(skillTarget.transform, initdamage, useSkill.skilltype);
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) 
        {
            EnemyInstances.enemyDict.TryGetValue(skillCaster.name, out Enemy enemy);
            float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, enemy.returnADAP(useSkill.skilltype)); 
            Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
            GameManager.Instance.player.GetComponent<PlayerStatus>().PlayerGetDamage(initdamage, skilltype); 
            SkillSystem.Instance.ShowSkillAnimation(useSkill.skillName, skillCaster.transform.position, GameManager.Instance.player.transform.position);
        }
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
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell) 
        {
            //1, ��ų ���� �� ���� enemy�� �ִ��� ������ check�ؾ���.
            //2. �� enemy ������ �޾ƿ;���.
            //3. ���� �ִٸ� -> ���������, ���...
            Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
            foreach (var inenemy in CheckRangeEnemy(targetCell))
            {
                EnemyInstances.enemyDict.TryGetValue(inenemy.name, out Enemy enemy);
                //Debug.Log($"{inenemy.name}�� ������ ����");
                float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, GameManager.Instance.player.GetComponent<PlayerStatus>().returnADAP(useSkill.skilltype));
                enemy.TakeDamage(inenemy.transform, initdamage, useSkill.skilltype);
                //Debug.Log($"{inenemy.name}�� HP : {enemy.HP}, ���� ���� : {initdamage}");
                SkillSystem.Instance.ShowSkillAnimation(useSkill.skillName, skillCaster.transform.position, inenemy.transform.position);
            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) { }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster) 
        {
            EnemyInstances.enemyDict.TryGetValue(skillCaster.name, out Enemy enemy);
            Vector3Int playerCellPos = GameManager.Instance.PlayerWorldToCell(GameManager.Instance.player.transform.position);
            bool? isfuck = GameManager.Instance.IsTargetOnCell(playerCellPos); // �� �� ���� �÷��̾ �ִٸ�(�÷��̾ �ִ� �� ��ġ == IstargetOnCell())
            if (isfuck.HasValue) // ���࿡ ��ų ���� �ȿ� �ִٸ�.
            {
                float initdamage = GameManager.Instance.DamageSystem(useSkill.coefficient, useSkill.skilltype, enemy.returnADAP(useSkill.skilltype));
                // �÷��̾�� ������ �ִ� �Լ�.
                Skill_AudioManage.Instance.PlaySkillAudio(useSkill.skillName);
                GameManager.Instance.player.GetComponent<PlayerStatus>().PlayerGetDamage(initdamage, skilltype);
                //Debug.Log($"{skillCaster.name}���԰��ݴ��޴ٴ°��� {useSkill.skillName} {skillCaster.transform.position}, {GameManager.Instance.player.GetComponent<Transform>().position}");
                SkillSystem.Instance.ShowSkillAnimation(useSkill.skillName, skillCaster.transform.position, GameManager.Instance.player.transform.position);
            }
        }
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
