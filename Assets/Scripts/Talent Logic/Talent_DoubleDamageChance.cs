using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent_DoubleDamageChance : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float doubleDamageChance;
    [SerializeField] private float randomResult;
    public bool isDoubleDamage;
    public  void ImplementTalent(Sword playerSword)
    {
        randomResult = Random.Range(0f, 99f);
        if (randomResult <= doubleDamageChance)
        {
            playerSword.SetSwordDamage(2 * playerSword.swordDamage_);
            Debug.Log(playerSword.swordDamage_);
        }
            
    }
}
