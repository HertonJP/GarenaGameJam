using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int playerMaxHP = 100;
    public int playerHP;
    public int playerDamage = 10;
    public bool canBeDamaged = true;
    public TalentManager talentManager;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = playerMaxHP;
        if (talentManager.CheckTalentTakenIndexByName("Immune") != -1)
        {
            GetComponent<Immune>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damageRecieved)
    {
        playerHP -= damageRecieved;
    }
}
