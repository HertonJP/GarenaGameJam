using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immune : MonoBehaviour
{
    public float immuneDuration;
    public float immuneInterval;
    public bool isImmune;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (true)
        {
            if (!isImmune)
            {
                StartCoroutine(ImmuneIntervalDuration());
            }
            else
            {
                GetComponent<PlayerStats>().canBeDamaged = false;
                StartCoroutine(ImmuneDuration());
            }
        }
    }
    private IEnumerator ImmuneDuration()
    {
        yield return new WaitForSeconds(immuneDuration);
        isImmune = false;
        GetComponent<PlayerStats>().canBeDamaged = true;
    }

    private IEnumerator ImmuneIntervalDuration()
    {
        yield return new WaitForSeconds(immuneInterval);
        isImmune = true;
    }
}
