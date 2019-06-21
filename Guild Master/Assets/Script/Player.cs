using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;

    //currencies
    double v_gold;
    public Text gold_Text;
    public double gold
    {
        get
        {
            return v_gold;
        }
        set
        {
            v_gold = value;
            NumberConverter num = new NumberConverter();
            gold_Text.text = num.numberConverter(v_gold);
        }
    }
    
    int gems;

    double v_loot;
    public Text loot_Text;
    public double loot
    {
        get
        {
            return v_loot;
        }
        set
        {
            v_loot = value;
            NumberConverter num = new NumberConverter();
            loot_Text.text = num.numberConverter(v_loot);
        }
    }

    int keys;
    int prestige;

    //members

    //equipments

    //personal stats
    public int maxLevel = 99;
    int levels;
    double dps = 4;
    int wealth;

    public GameObject particle;
    Rect playArea = new Rect(0, Screen.height / 4, Screen.width, Screen.height / 2);
    // Calculate other rectangles

    void Start()
    {
        if(instance == null)
        {
            Debug.Log("here");
            instance = this;
        }
        gold = 30;
        loot = 0;
    }

    private void Update()
    {
        //PC controls
        if (Input.GetMouseButtonDown(0))
        {
            if (playArea.Contains(Input.mousePosition))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray,out hit, 100f))
                {
                    DamageManager.instance.Tap(hit.point, dps);
                    
                }
            }
        }
    }
}
