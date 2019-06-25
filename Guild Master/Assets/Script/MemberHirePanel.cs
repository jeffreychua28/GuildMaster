using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberHirePanel : MonoBehaviour
{
    public Adventurer adventurer;

    public Image levelBar;
    public Image wealthBar;
    public Text Price;
    public Text damageText;

    public void showcaseAdventurer()
    {
        Debug.Log(adventurer.level);
        levelBar.fillAmount = (float)adventurer.level / (float)Player.instance.maxLevel;
        wealthBar.fillAmount = (float)adventurer.wealth / (float)Player.instance.maxLevel;
        switch (adventurer.tier)
        {
            case 0: break;
            case 1: levelBar.color =new Color32(255,116,0,255);break;
            case 2: levelBar.color = new Color32(255, 196, 0, 255);break;
            case 3: levelBar.color = new Color32(237, 255, 0, 255);break;
            case 4: levelBar.color = new Color32(144, 255, 0, 255);break;
            case 5: levelBar.color = new Color32(96, 255, 0, 255);break;
        }

        NumberConverter num = new NumberConverter();
        string damage = num.numberConverter(adventurer.damage());
        damageText.text = damage;

        string price = num.numberConverter(adventurer.price);
        Price.text = price;
    }

    public void Purchase()
    {
        GuildHall.instance.BuyAdventurer(this.gameObject);
    }
}
