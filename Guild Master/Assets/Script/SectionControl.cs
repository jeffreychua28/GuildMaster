using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionControl : MonoBehaviour
{
    public Animator guildAnimator;
    

    public void activatePanel(int id)
    {
        //DEPENDING ON THE ID, ACTIVATE PANEL AND DEACTIVATE THE REST
        //FOR NOW ITS GUILD ONLY
        guildAnimator.SetTrigger("Activate");
    }

    public void deActivatePanel(Animator animator)
    {
        //same goes for this
        guildAnimator.SetTrigger("Deactivate");
    }
}
