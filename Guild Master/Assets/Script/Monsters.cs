using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "IdleGame/Monster", order = 1)]
public class Monsters : ScriptableObject
{
    double experienceBase;
    public double experience()
    {
        return 0;
    }

    double goldBase = 100;
    public double gold()
    {
        return (health() / 10) * level;
    }

    double lootBase = 2;
    public double loot()
    {
        return (lootBase * monsterCoe * Mathf.Pow(level, (2f + ((float)level / 15f))/ (float)(4 - (level-15))));
    }
    
    public double health()
    {
        double healthBase = 12;
        return (healthBase * monsterCoe * Mathf.Pow(2 * level, (3 + ((float)level/15))));
    }

    public double upgradePrice()
    {
        double upgradeBase = 10;
        return (upgradeBase * monsterCoe * Mathf.Pow(level, 3f));
    }
    public int level = 1;
    public float monsterCoe;



    //0-1f
    public float key_drop;
}
