using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TalentSO[] takenTalents;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckTalentTaken(string TalentName)
    {
        foreach(TalentSO t in takenTalents)
        {
            if (t.isTaken)
                return true;
        }
        return false;
    }
}
