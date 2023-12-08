using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent_Immune : TalentBase
{
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void ImplementTalent()
    {
        player.GetComponent<Immune>().canImmune = true;
    }
}
