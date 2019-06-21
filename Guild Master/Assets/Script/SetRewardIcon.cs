using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRewardIcon : MonoBehaviour
{
    public Text value;
    public Image icon;

  
    public void setup(string text, Sprite icon2)
    {
        value.text = text;
        icon.sprite = icon2;
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
