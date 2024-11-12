using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillList // ������ �� ��ų�� ����� ����ִ� ��.
{
    public class MagicBullet : ActiveSkill
    {
        public MagicBullet(SkillData data) : base(data) {} // initializer
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, Vector3Int targetCell)
        {
            if (skillCaster.CompareTag("player"))
            {
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
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
                //1. Ÿ�ټ��� 
                //Debug.Log($"{skillCaster} �� ����!");

            }
        }
        public override void CastSkill(ActiveSkill useSkill, GameObject skillCaster, GameObject skillTarget) // ������� ��ų
        {
            if (skillCaster.CompareTag("Player"))
            {
                //1. Ÿ�ټ��� 
                Debug.Log($"{skillCaster} �� ����!");
                //TODO : ��ų ���󰡴� �޼ҵ� �����. ����޼ҵ�
            }
        }
    }
}
