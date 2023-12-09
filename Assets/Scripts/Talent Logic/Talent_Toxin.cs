using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent_Toxin : MonoBehaviour
{
    [SerializeField] private TalentManager talentManager;
    [SerializeField] private int toxinDamage;
     private float toxinDuration;
    [SerializeField] private float currToxinDuration;
    public Enemy targetEnemy;
    // Start is called before the first frame update
    void Start()
    {
        currToxinDuration = toxinDuration;
    }

    public void Update()
    {
        toxinDuration -= Time.deltaTime;

        if (toxinDuration > 0 && targetEnemy != null)
        {
            currToxinDuration -= Time.deltaTime;
            targetEnemy.TakeDamage(toxinDamage);
        }
        else
        {
            currToxinDuration = toxinDuration;
        }
    }
}
