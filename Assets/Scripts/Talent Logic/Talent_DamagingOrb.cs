using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent_DamagingOrb : MonoBehaviour
{
    [SerializeField] private TalentManager talentManager;
    [SerializeField] private GameObject orbPivot;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (talentManager.CheckTalentTakenIndexByName("Orb") != -1)
        {
            Debug.Log("orb");
            orbPivot.SetActive(true);
        }
    }
}
