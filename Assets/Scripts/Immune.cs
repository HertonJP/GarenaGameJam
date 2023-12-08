using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immune : MonoBehaviour
{
    public float immuneDuration;
    public float immuneInterval;
    public bool isImmune;
    bool hasStartInterval;
    bool hasStartImmune;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isImmune)
        {   
            if(!hasStartInterval)
                StartCoroutine(ImmuneIntervalDuration());
        }
        else
        {
            if (!hasStartImmune)
            {
                GetComponent<PlayerStats>().canBeDamaged = false;
                GetComponent<SpriteRenderer>().color = Color.red;
                StartCoroutine(ImmuneDuration());
            }
        }
    }
    private IEnumerator ImmuneDuration()
    {
        hasStartImmune = true;
        Debug.Log("b");
        yield return new WaitForSeconds(immuneDuration);
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<PlayerStats>().canBeDamaged = true;
        isImmune = false;
        hasStartImmune = false;
    }

    private IEnumerator ImmuneIntervalDuration()
    {
        hasStartInterval = true;
        Debug.Log("a");
        yield return new WaitForSeconds(immuneInterval);
        isImmune = true;
        hasStartInterval = false;
    }
}
