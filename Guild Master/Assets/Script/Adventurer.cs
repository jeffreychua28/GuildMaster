using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer
{
    public int id;
    public enum type
    {
        dps,
        tank,
        healer,
        gatherer
    }

    public type heroType;
    public int level;
    public int wealth;

    //dps
    public double dps = 2;
    public int tier;

    public float priceRatio;
    public double price;

    public bool available;
    public double currentExperience;

    float classCoe()
    {
        switch (heroType)
        {
            case type.dps: return 1.1f;
            case type.tank: return 1f;
            case type.healer: return 0.98f;
            case type.gatherer: return 0.96f;
        }
        return 1f;
    }

    int baseEXP = 60;
    public double expRequired()
    {
        return classCoe() * baseEXP * Mathf.Pow(level,(1+ (level/20)));
    }

    int baseWealth = 5;
    public double wealthCost()
    {
        return classCoe() * (1-((5 - tier) * 0.05f)) * baseWealth * Mathf.Pow(wealth, (3f + ((float)wealth/10f))); 
    }

    int baseDamage = 5;
    public double damage()
    {
        return classCoe()  * (1 + (level * baseDamage * 0.5f)) * wealth * (1+ (0.2f * tier));
    }
    //skills

    public void SetMeUp(int v_level, int v_wealth, int v_tier,  Adventurer.type hero)
    {
        level = v_level;
        wealth = v_wealth;
        tier = v_tier;
       
        heroType = hero;
        
        dps = damage();
        price = tier * (damage()/1.5f) * classCoe() * 5;
        id = Random.Range(0, 100000000);
        available = true;
    }
}
