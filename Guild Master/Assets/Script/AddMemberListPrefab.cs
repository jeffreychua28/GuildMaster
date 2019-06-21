using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMemberListPrefab : MonoBehaviour
{
    [HideInInspector]
    public Adventurer adv;
    public Image level;
    public Image wealth;

    Transform canvas;

    bool active;
    
    //only used by the explorationaddmember to remember its current position
    public int positionID = 0;

    public void setMeUp(Adventurer adventurer, Transform canv)
    {
        canvas = canv;
        adv = adventurer;
        switch (adv.tier)
        {
            case 0: break;
            case 1: level.color = new Color32(255, 116, 0, 255); break;
            case 2: level.color = new Color32(255, 196, 0, 255); break;
            case 3: level.color = new Color32(237, 255, 0, 255); break;
            case 4: level.color = new Color32(144, 255, 0, 255); break;
            case 5: level.color = new Color32(96, 255, 0, 255); break;
        }
        level.fillAmount = (float)adv.level / (float)Player.instance.maxLevel;
        wealth.fillAmount = (float)adv.wealth / (float)Player.instance.maxLevel;
    }

    public void addPartyMember()
    {
        //if its already helping the damage and already part of the party member
        if (active)
        {
            EnemyManager.instance.removePartyMember(adv.id);
            Adventurer adven = GuildHall.instance.adventurer.Find(x => x.id == adv.id);
            adven.available = true;
            canvas.gameObject.GetComponent<ExplorationAddMember>().removeMember(positionID);
            Destroy(this.gameObject);
        }

        //tries to add party member, if it succeed
        if (!active && EnemyManager.instance.addPartyMember(this.gameObject)  )
        {
            Adventurer adven = GuildHall.instance.adventurer.Find(x => x.id == adv.id);
            adven.available = false;

            canvas.gameObject.GetComponent<ExplorationAddMember>().moveMember(this.gameObject);

            active = true;
        }
    }
}
