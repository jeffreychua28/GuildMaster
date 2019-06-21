using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent : ScriptableObject
{
    public enum talentType
    {
        ClickIncrease,
        DamageIncrease,
        RewardIncrease,
        GuildLevelStart,
        FasterAdventurerSearch,
    }

    public float value;
    public int level;
    public double basePrice;
    public double Price
    {
        get
        {
            return basePrice * level;
        }
    }
}
