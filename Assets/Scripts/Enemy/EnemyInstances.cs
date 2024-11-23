using Enemyspace;
using Spine.Unity.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyList;

public class EnemyInstances : MonoBehaviour
{
    public static Dictionary<string, Enemy> enemyDict = new Dictionary<string, Enemy>();
    private void Awake()
    {
        InitializeEnemy();
    }
    private void InitializeEnemy()
    {
        EnemyData[] enemyDataList = Resources.LoadAll<EnemyData>("EnemyData");

        foreach (var data in enemyDataList)
        {
            switch (data.Name)
            {
                // Slime
                case "Slime":
                    enemyDict[data.Name] = new Slime(data);
                    break;
                case "Slime1":
                    enemyDict[data.Name] = new Slime1(data);
                    break;
                case "Slime2":
                    enemyDict[data.Name] = new Slime2(data);
                    break;
                case "Slime3":
                    enemyDict[data.Name] = new Slime3(data);
                    break;

                // WeedSpirit
                case "WeedSpirit":
                    enemyDict[data.Name] = new WeedSpirit(data);
                    break;
                case "WeedSpirit1":
                    enemyDict[data.Name] = new WeedSpirit1(data);
                    break;
                case "WeedSpirit2":
                    enemyDict[data.Name] = new WeedSpirit2(data);
                    break;
                case "WeedSpirit3":
                    enemyDict[data.Name] = new WeedSpirit3(data);
                    break;

                // GiantRat
                case "GiantRat":
                    enemyDict[data.Name] = new GiantRat(data);
                    break;
                case "GiantRat1":
                    enemyDict[data.Name] = new GiantRat1(data);
                    break;
                case "GiantRat2":
                    enemyDict[data.Name] = new GiantRat2(data);
                    break;
                case "GiantRat3":
                    enemyDict[data.Name] = new GiantRat3(data);
                    break;

                // Goblin
                case "Goblin":
                    enemyDict[data.Name] = new Goblin(data);
                    break;
                case "Goblin1":
                    enemyDict[data.Name] = new Goblin1(data);
                    break;
                case "Goblin2":
                    enemyDict[data.Name] = new Goblin2(data);
                    break;
                case "Goblin3":
                    enemyDict[data.Name] = new Goblin3(data);
                    break;

                // Default
                default:
                    Debug.LogWarning($"없는게 들어옴 {data.Name}");
                    break;
            }

        }
    }
}
