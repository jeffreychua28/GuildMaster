using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberUpgradePanel : MonoBehaviour
{
    public Adventurer adventurer;

    public Image levelBar;
    public Image wealthBar;
    public Text Price;

    

    public void Upgrade()
    {
        PurchaseCheck check = new PurchaseCheck();
        if (check.ableToPurchase(adventurer.wealthCost()))
        {
            if(adventurer.wealth <= Player.instance.maxLevel)
            {
                Player.instance.gold -= adventurer.wealthCost();
                adventurer.wealth += 1;
                EnemyManager.instance.updateMemberListArea();
                MemberPanel.instance.setupPanel();
                MemberPanel.instance.DetailedMember(adventurer);
            }
        }
    }
}
