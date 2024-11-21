using System;
using System.Collections.Generic;
using UnityEngine;

public class Relic
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Func<GameCondition, bool> Condition { get; private set; } // ����
    public Action<GameCondition> Effect { get; private set; }       // ȿ��

    public Relic(string name, string description, Func<GameCondition, bool> condition, Action<GameCondition> effect)
    {
        Name = name;
        Description = description;
        Condition = condition;
        Effect = effect;
    }

    public void CheckAndApply(GameCondition condition)
    {
        if (Condition.Invoke(condition))
        {
            Effect.Invoke(condition);
        }
    }
}