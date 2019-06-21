using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public Monsters monster;
    public Animator animator;

    public GameObject HP_Color;
    public Text HP_Text;

    public Sprite[] rewardIcons;
    public GameObject rewardPrefab;
    public Transform canvas;

    public Text PartyDamage;

    partyMember party = new partyMember();
    double partyDamage;

    bool death;
    float timer;

    double v_currentHealth;
    double currentHealth
    {
        get
        {
            return v_currentHealth;
        }
        set
        {
            v_currentHealth = value;
            HP_UI_Change(v_currentHealth);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
          
        } else
        {
            instance = this;
        }

        currentHealth = monster.health();
        updateMonsterArea();
    }

    private void Update()
    {
        if (!death)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5f)
            {
                timer = 0;
                if(partyDamage > 0)
                {
                    currentHealth -= (partyDamage/2);
                }
            }
        }
       
    }

    public void tapDamage(double damage)
    {
        if (!death)
        {
            currentHealth -= damage;
        }
    }
    
    public void HP_UI_Change(double value)
    {
        double percentage = (double)value / (double)monster.health();
        //hard coded height coz unity doesnt allow y changes for recttransform
        HP_Color.GetComponent<Image>().fillAmount = (float)percentage;


        //NEEDS TO GO THROUGH THE NUMBER CONVERTER!!!!!!
        //!!!!!!!!!!!!!!!
        if (!animator.GetBool("dead"))
        {
            animator.SetTrigger("Hurt");
        }
        NumberConverter num = new NumberConverter();
        string healthConverted = num.numberConverter(currentHealth);
        if(currentHealth > 0)
        {

            HP_Text.text = healthConverted + " HP";
        } else
        {
            animator.SetBool("dead", true);
            HP_Text.text = " Death";
            death = true;
            for(int i = 0; i < 3; i++)
            {
                StartCoroutine(OnDeath(i));
            }
            rebirth();
        }
    }

    public void rebirth()
    {
        currentHealth = monster.health();
        death = false;
    }

    IEnumerator OnDeath(int i)
    {
        yield return new WaitForSeconds(0.3f * i);
        GameObject obj = Instantiate(rewardPrefab);
        obj.transform.SetParent(canvas);
        obj.transform.SetSiblingIndex(0);
        double value = 0;

        //DONT FORGET TO GIVE EXP TO THE PLAYERS
        //!!!!!!!!!!!!!!!!!!!
        switch (i)
        {
            case 0: value = monster.experience(); break;
            case 1: value = monster.gold(); Player.instance.gold += value; break;
            case 2: value = monster.loot(); Player.instance.loot += value; break;
        }
        NumberConverter num = new NumberConverter();
        
        obj.GetComponent<SetRewardIcon>().setup(num.numberConverter(Mathf.Round((float)value)).ToString(), rewardIcons[i]);

       
    }

    public bool addPartyMember(GameObject adv)
    {
        if(party.adventurer.Count < 5)
        {
            party.adventurer.Add(adv);
            partyDamage += Mathf.Round((float)adv.GetComponent<AddMemberListPrefab>().adv.damage());
            NumberConverter num = new NumberConverter();
            PartyDamage.text = num.numberConverter(partyDamage);
            return true;
        }
        //return false if it cant fit
        return false;
    }

    public void removePartyMember(int id)
    {
        GameObject adv = party.adventurer.Find(x => x.GetComponent<AddMemberListPrefab>().adv.id == id);
        Debug.Log(party.adventurer.Count);
        party.adventurer.Remove(adv);
        Debug.Log(party.adventurer.Count);
        partyDamage -= Mathf.Round(((float)adv.GetComponent<AddMemberListPrefab>().adv.damage()));
        NumberConverter num = new NumberConverter();
        PartyDamage.text = num.numberConverter(partyDamage);
    }

    public void updatePartyDamage()
    {
        partyDamage = 0;
        for(int i = 0; i < party.adventurer.Count; i++)
        {
            partyDamage += party.adventurer[i].GetComponent<AddMemberListPrefab>().adv.damage();
        }
        NumberConverter num = new NumberConverter();
        PartyDamage.text = num.numberConverter(partyDamage);
    }
    
    public void upgradeMonster()
    {
        PurchaseCheck pc = new PurchaseCheck();
        if (pc.ableToPurchase(monster.upgradePrice()))
        {
            if(monster.level < Player.instance.maxLevel)
            {
                Player.instance.gold -= monster.upgradePrice();
                monster.level += 1;
                Debug.Log(monster.upgradePrice());
                updateMonsterArea();
            }

        }
    }

    public void updateMemberListArea()
    {
        for(int i = 0; i < party.adventurer.Count; i++)
        {
            party.adventurer[i].GetComponent<AddMemberListPrefab>().setMeUp(party.adventurer[i].GetComponent<AddMemberListPrefab>().adv, party.adventurer[i].transform.parent);
        }
        updatePartyDamage();
    }

    public Text GoldReward;
    public Text LootReward;
    public Text KeyPercentage;
    public Text UpgradeCost;
    public void updateMonsterArea()
    {
        NumberConverter num = new NumberConverter();
        GoldReward.text = num.numberConverter( monster.gold());
        LootReward.text = num.numberConverter(monster.loot());
        KeyPercentage.text = monster.key_drop.ToString() + "%";
        rebirth();
        UpgradeCost.text = num.numberConverter(monster.upgradePrice());
    }
}

public class partyMember
{
    public List<GameObject> adventurer = new List<GameObject>();
}
