using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ActiveSkillList;

public class SkillInstance : MonoBehaviour
{
    public static Dictionary<string, ActiveSkill> skillInstances = new Dictionary<string, ActiveSkill>(); // 스킬을 저장하는 Active Skill 생성. 

    private void Start()
    {
        InitializeSkills();
    }
    private void InitializeSkills()
    {
        // Resources 폴더에서 모든 SkillData를 불러와서 인스턴스 생성
        SkillData[] allSkillData = Resources.LoadAll<SkillData>("SkillData");
        Debug.Log(allSkillData.Length);
        if (allSkillData != null)
        {
            Debug.Log("제대로 불러옴");
        }        
        else
        {
            Debug.Log("제대로 못불러옴");
        }
        foreach (var data in allSkillData)
        {
            // 스킬 이름에 따라 새로운 ActiveSkill 인스턴스 생성
            if (data.skillName == "MagicBullet")
            {
                skillInstances[data.skillName] = new MagicBullet(data);
            }
            else if (data.skillName == "Bite")
            {
                skillInstances[data.skillName] = new Bite(data);
            }
            else if (data.skillName == "Decay")
            {
                skillInstances[data.skillName] = new Decay(data);
            }
            else if (data.skillName == "ManaDrain")
            {
                skillInstances[data.skillName] = new ManaDrain(data);
            }
            else if (data.skillName == "Smash")
            {
                skillInstances[data.skillName] = new Smash(data);
            }
            else if (data.skillName == "Harden")
            {
                skillInstances[data.skillName] = new Harden(data);
            }
            else if (data.skillName == "Ambush")
            {
                skillInstances[data.skillName] = new Ambush(data);
            }
            else if (data.skillName == "VenomousFang")
            {
                skillInstances[data.skillName] = new VenomousFang(data);
            }
            else if (data.skillName == "Aftershock")
            {
                skillInstances[data.skillName] = new Aftershock(data);
            }
            else if (data.skillName == "GhostlyGrasp")
            {
                skillInstances[data.skillName] = new GhostlyGrasp(data);
            }
            else if (data.skillName == "Fireball")
            {
                skillInstances[data.skillName] = new Fireball(data);
            }
            else if (data.skillName == "Rage")
            {
                skillInstances[data.skillName] = new Rage(data);
            }
            else if (data.skillName == "Flame")
            {
                skillInstances[data.skillName] = new Flame(data);
            }
            else if (data.skillName == "IronShield")
            {
                skillInstances[data.skillName] = new IronShield(data);
            }
            else if (data.skillName == "Sweep")
            {
                skillInstances[data.skillName] = new Sweep(data);
            }
            else if (data.skillName == "IceArrow")
            {
                skillInstances[data.skillName] = new IceArrow(data);
            }
            else if (data.skillName == "CloakAndReveal")
            {
                skillInstances[data.skillName] = new CloakAndReveal(data);
            }
            else if (data.skillName == "LifeTransfusion")
            {
                skillInstances[data.skillName] = new LifeTransfusion(data);
            }
            else if (data.skillName == "GreatMagicShield")
            {
                skillInstances[data.skillName] = new GreatMagicShield(data);
            }
            else if (data.skillName == "Vampirism")
            {
                skillInstances[data.skillName] = new Vampirism(data);
            }
            else if (data.skillName == "RapidStrike")
            {
                skillInstances[data.skillName] = new RapidStrike(data);
            }
            else if (data.skillName == "Tear")
            {
                skillInstances[data.skillName] = new Tear(data);
            }
            else if (data.skillName == "Scream")
            {
                skillInstances[data.skillName] = new Scream(data);
            }
            else if (data.skillName == "AcidicBody")
            {
                skillInstances[data.skillName] = new AcidicBody(data);
            }
            else if (data.skillName == "UnstableMixture")
            {
                skillInstances[data.skillName] = new UnstableMixture(data);
            }
            else if (data.skillName == "FlameCharge")
            {
                skillInstances[data.skillName] = new FlameCharge(data);
            }
            else if (data.skillName == "FlameClaws")
            {
                skillInstances[data.skillName] = new FlameClaws(data);
            }
            else if (data.skillName == "Aiming")
            {
                skillInstances[data.skillName] = new Aiming(data);
            }
            else if (data.skillName == "Calcification")
            {
                skillInstances[data.skillName] = new Calcification(data);
            }
            else if (data.skillName == "Intimidate")
            {
                skillInstances[data.skillName] = new Intimidate(data);
            }
            else if (data.skillName == "Plunder")
            {
                skillInstances[data.skillName] = new Plunder(data);
            }
            else if (data.skillName == "Ignite")
            {
                skillInstances[data.skillName] = new Ignite(data);
            }
            else if (data.skillName == "FlamePillar")
            {
                skillInstances[data.skillName] = new FlamePillar(data);
            }
            else if (data.skillName == "Possession")
            {
                skillInstances[data.skillName] = new Possession(data);
            }
            else if (data.skillName == "CursedSword")
            {
                skillInstances[data.skillName] = new CursedSword(data);
            }
            else if (data.skillName == "Blizzard")
            {
                skillInstances[data.skillName] = new Blizzard(data);
            }
            else if (data.skillName == "Frostbite")
            {
                skillInstances[data.skillName] = new Frostbite(data);
            }
            else if (data.skillName == "FlameBreath")
            {
                skillInstances[data.skillName] = new FlameBreath(data);
            }
            else if (data.skillName == "ForwardThrust")
            {
                skillInstances[data.skillName] = new ForwardThrust(data);
            }
            else if (data.skillName == "SpearOfBlood")
            {
                skillInstances[data.skillName] = new SpearOfBlood(data);
            }
            else if (data.skillName == "MistForm")
            {
                skillInstances[data.skillName] = new MistForm(data);
            }
            else if (data.skillName == "SlashAndCut")
            {
                skillInstances[data.skillName] = new SlashAndCut(data);
            }
            else if (data.skillName == "Howl")
            {
                skillInstances[data.skillName] = new Howl(data);
            }
            else if (data.skillName == "Rake")
            {
                skillInstances[data.skillName] = new Rake(data);
            }
            else if (data.skillName == "EarthOfFire")
            {
                skillInstances[data.skillName] = new EarthOfFire(data);
            }
            else if (data.skillName == "WeaponOfFire")
            {
                skillInstances[data.skillName] = new WeaponOfFire(data);
            }
            else if (data.skillName == "Volcano")
            {
                skillInstances[data.skillName] = new Volcano(data);
            }
            else if (data.skillName == "Crossfire")
            {
                skillInstances[data.skillName] = new Crossfire(data);
            }
            else if (data.skillName == "ExecutionersGreatSword")
            {
                skillInstances[data.skillName] = new ExecutionersGreatSword(data);
            }
            else if (data.skillName == "Execution")
            {
                skillInstances[data.skillName] = new Execution(data);
            }
        }
    }
 }

