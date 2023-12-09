using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent_Immune : MonoBehaviour
{
    public GameObject player;
    public TalentManager talentManager;
    private void Update()
    {
        if (talentManager.takenTalents[0] != null && talentManager.CheckTalentTakenIndexByName("Immune") != -1)
        {
            ImplementTalent();
        }
    }

    public  void ImplementTalent()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Immune>().enabled = true;
    }
}
