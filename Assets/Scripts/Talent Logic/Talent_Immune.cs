using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent_Immune : MonoBehaviour
{
    public GameObject player;
    public TalentManager talentManager;
    private void Update()
    {
        if (talentManager.CheckTalentTakenIndexByName("Immune") != -1)
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
