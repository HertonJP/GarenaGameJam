using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent_SwordEnlargemnet : MonoBehaviour
{
    public Vector2 newSwordSize;
    public TalentManager talentManager;

    private void Update()
    {
        if(talentManager.CheckTalentTakenIndexByName("Magnifier") != -1)
        {
            Debug.Log("Sword enla");
            Implementation(GetComponent<Sword>());
        }
            
    }

    public void Implementation(Sword sword)
    {
        sword.gameObject.transform.localScale = newSwordSize;
    }
}
