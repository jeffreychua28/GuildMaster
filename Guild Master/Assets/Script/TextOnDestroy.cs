using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnDestroy : MonoBehaviour
{
    public void destroyMe()
    {
        Destroy(this.gameObject);
    }
}
