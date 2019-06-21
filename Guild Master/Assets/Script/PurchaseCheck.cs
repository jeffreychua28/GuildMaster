using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseCheck
{
    public bool ableToPurchase(double price)
    {
        if (price <= Player.instance.gold)
        {
            return true;
        }
        return false;
    }
}
