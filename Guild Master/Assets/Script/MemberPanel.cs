using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberPanel : MonoBehaviour
{
    public static MemberPanel instance;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public GameObject memberListPrefab;
    public Transform memberList;

    //show member
    public Image level;
    public Image wealth;
    public Text dpsText;

    public MemberUpgradePanel upgrade;

    public Text priceText;

    Adventurer adv;
    public void DetailedMember(Adventurer DisplayAdv)
    {
        adv = DisplayAdv;
        switch (adv.tier)
        {
            case 0: break;
            case 1: level.color = new Color32(255, 116, 0, 255); break;
            case 2: level.color = new Color32(255, 196, 0, 255); break;
            case 3: level.color = new Color32(237, 255, 0, 255); break;
            case 4: level.color = new Color32(144, 255, 0, 255); break;
            case 5: level.color = new Color32(96, 255, 0, 255); break;
        }

        wealth.fillAmount = (float)adv.wealth / (float)Player.instance.maxLevel;
        level.fillAmount = (float)adv.level / (float)Player.instance.maxLevel;

        upgrade.adventurer = adv;

        NumberConverter num = new NumberConverter();
        dpsText.text = "(" + adv.level + ")" + num.numberConverter(Mathf.Round((float)adv.damage()));
        priceText.text = num.numberConverter(adv.wealthCost());
    }

    //show all member
    void ShowMember()
    {
        for(int i = 0; i < memberList.childCount; i++)
        {
            Destroy(memberList.GetChild(i).gameObject);
        }
        for(int i = 0; i < GuildHall.instance.adventurer.Count; i++)
        {
            GameObject go = Instantiate(memberListPrefab);
            go.transform.SetParent(memberList);
            go.GetComponent<MemberListPrefab>().Setup(GuildHall.instance.adventurer[i]);
        }
    }

    public void UpgradeAdventurer()
    {
        PurchaseCheck pc = new PurchaseCheck();
        if (pc.ableToPurchase(adv.wealthCost()))
        {
            if(adv.wealth < Player.instance.maxLevel)
            {
                Debug.Log(adv.wealthCost());
                Player.instance.gold -= adv.wealthCost();
                adv.wealth += 1;
                setupPanel();
            }
        }
    }

    public void setupPanel()
    {
        Debug.Log(GuildHall.instance.adventurer.Count);

        ShowMember();
    }
}
