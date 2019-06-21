using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberListPrefab : MonoBehaviour
{
    public Image Wealth;
    public Image Level;

    Adventurer adv;

    public void Setup(Adventurer newAdv)
    {
        adv = newAdv;
        switch (adv.tier)
        {
            case 0: break;
            case 1: Level.color = new Color32(255, 116, 0, 255); break;
            case 2: Level.color = new Color32(255, 196, 0, 255); break;
            case 3: Level.color = new Color32(237, 255, 0, 255); break;
            case 4: Level.color = new Color32(144, 255, 0, 255); break;
            case 5: Level.color = new Color32(96, 255, 0, 255); break;
        }

        Wealth.fillAmount = (float)adv.wealth / (float)Player.instance.maxLevel;
        Level.fillAmount = (float)adv.level / (float)Player.instance.maxLevel;
    }

    public void Clicked()
    {
        MemberPanel.instance.DetailedMember(adv);
    }
}
