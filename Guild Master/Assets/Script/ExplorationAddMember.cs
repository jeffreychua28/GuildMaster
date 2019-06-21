using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationAddMember : MonoBehaviour
{
    public GameObject member;
    public Transform contentPanel;
    

    public Transform[] memberList;
    bool[] filled = new bool[4];
    private void OnEnable()
    {
        for(int i = 0; i < contentPanel.childCount; i++)
        {
            Destroy(contentPanel.GetChild(i).gameObject);
        }
        GuildHall g = GuildHall.instance;
        for(int i = 0; i < g.adventurer.Count; i++)
        {
            if (g.adventurer[i].available)
            {
                GameObject mmb = Instantiate(member);
                mmb.transform.SetParent(contentPanel);
                mmb.GetComponent<AddMemberListPrefab>().setMeUp(g.adventurer[i],this.transform);
                
            }
        }
    }

    public void moveMember(GameObject obj)
    {
        for(int i = 0; i < memberList.Length; i++)
        {
            if (!filled[i])
            {
                obj.transform.SetParent(memberList[i]);
                obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(40, -50);
                obj.GetComponent<AddMemberListPrefab>().positionID = i;
                filled[i] = true;
                break;
            }
        }
    }

    public void removeMember(int id)
    {
        filled[id] = false;
    }
}
