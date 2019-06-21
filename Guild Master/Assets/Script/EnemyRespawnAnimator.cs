using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawnAnimator : MonoBehaviour
{
    public void respawn()
    {
        GetComponent<Animator>().SetBool("dead", false);
    }
}
