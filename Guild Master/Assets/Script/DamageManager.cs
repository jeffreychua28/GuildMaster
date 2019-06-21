using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageManager : MonoBehaviour
{
    public static DamageManager instance;

    public GameObject damagePrefab;
    public GameObject damageText;
    public Transform monsterZone;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
        } else
        {
            instance = this;
        }
    }

    public void Tap(Vector3 position, double playerDamage)
    {
        NumberConverter num = new NumberConverter();
        string damageConverted = num.numberConverter(playerDamage);
        EnemyManager.instance.tapDamage(playerDamage);
        GameObject obj = Instantiate(damagePrefab, position, Quaternion.Euler(0, 0, Random.Range(45f, 135f)));
        Destroy(obj, 0.3f);
        GameObject obj2= Instantiate(damageText);

        //need to calculate damage
        obj2.GetComponent<Text>().text = damageConverted;
        obj2.transform.SetParent(monsterZone);

        obj2.transform.SetAsFirstSibling();

    }
}
