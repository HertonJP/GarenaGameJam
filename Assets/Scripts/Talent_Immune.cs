using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Talent_Immune : TalentBase
{
    public GameObject player;

    private void Start()
    {
        
    }

    public override void ImplementTalent()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Immune>().enabled = true;
    }
}
