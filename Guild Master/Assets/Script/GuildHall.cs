using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildHall : MonoBehaviour
{
    public static GuildHall instance;
    int level;
    int memberCapacity;

    public List<Adventurer> adventurer = new List<Adventurer>();
    //job post

    //skills

    //shop items


    //functions

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public GameObject memberListPanel;
    public Transform memberContentPanel;

    public void generateRandomMember(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject panel = GameObject.Instantiate(memberListPanel);
            panel.transform.SetParent(memberContentPanel,false);
            panel.GetComponent<MemberHirePanel>().adventurer = randomizeAdventurer();
            panel.GetComponent<MemberHirePanel>().showcaseAdventurer();
        }
    }

    public void BuyAdventurer(GameObject panel)
    {
        PurchaseCheck check = new PurchaseCheck();
        Adventurer adv= panel.GetComponent<MemberHirePanel>().adventurer;

        if (check.ableToPurchase(adv.price))
        {
            //take the money away
            Player.instance.gold -= adv.price;
            //add adventurer
            adventurer.Add(adv);
            Destroy(panel);
        }
    }

    Adventurer randomizeAdventurer()
    {
        Adventurer newPlayer = new Adventurer();
        int level = Random.Range(1, 2);
        int wealth = Random.Range(1, 2);
        int tier = Random.Range(1, 5);
        Adventurer.type heroType = Adventurer.type.dps;
        int hero = Random.Range(0, 3);
        switch (hero)
        {
            case 0: heroType = Adventurer.type.dps;break;
            case 1: heroType = Adventurer.type.gatherer;break;
            case 2: heroType = Adventurer.type.healer; break;
            case 3: heroType = Adventurer.type.tank;break;
        }

        newPlayer.SetMeUp(level, wealth, tier, heroType);

        return newPlayer;
    }

}
