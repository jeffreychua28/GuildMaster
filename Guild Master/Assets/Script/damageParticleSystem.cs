using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageParticleSystem : MonoBehaviour
{
    public Text text;
    public void setDamage(string damage)
    {
        text.text = damage;
    }
}
