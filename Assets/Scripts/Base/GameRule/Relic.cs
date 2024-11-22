using System;
using System.Collections.Generic;
using UnityEngine;

public class Relic
{
    public string Name;
    public string Description { get; private set; }
    public Func<GameCondition, bool> Condition { get; private set; } // 조건
    public Action<GameCondition> Effect { get; private set; }       // 효과
    public Sprite Image { get; private set; }       // 유물 이미지

    public Relic(string name, string description, Func<GameCondition, bool> condition, Action<GameCondition> effect, string imageName)
    {
        Name = name;
        Description = description;
        Condition = condition;
        Effect = effect;
        Image = Resources.Load<Sprite>($"Reliccon/{imageName}");
        if (Image == null)
            {
                Debug.LogWarning($"[Relic] Image not found: {imageName}");
            }
        else
            {
                Debug.Log($"[Relic] Image loaded successfully: {imageName}");
            }
    }

    public void CheckAndApply(GameCondition condition)
    {
        if (Condition.Invoke(condition))
        {
            Effect.Invoke(condition);
        }
    }
}