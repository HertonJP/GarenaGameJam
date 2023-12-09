using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent_Toxin : MonoBehaviour
{
    [SerializeField] private TalentManager talentManager;
    [SerializeField] private int toxinDamage;
    [SerializeField] private float toxinDuration;
    [SerializeField] private float currToxinDuration;
    [SerializeField] private float toxicInterval;
    public Enemy targetEnemy;
    public bool isDealing;
    // Start is called before the first frame update
    void Start()
    {
        currToxinDuration = toxinDuration;
    }

    public void Update()
    {
        if (toxinDuration > 0 && targetEnemy != null)
        {
            if(!isDealing)
                StartCoroutine(DealToxicDamage());
        }
        else
        {
            currToxinDuration = toxinDuration;
            this.enabled = false;
        }
    }
    
    private IEnumerator DealToxicDamage()
    {
        isDealing = true;
        yield return new WaitForSeconds(toxicInterval);
        targetEnemy.TakeDamage(toxinDamage);
        isDealing = false;
    }
}
