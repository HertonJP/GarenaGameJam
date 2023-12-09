using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TalentSO[] takenTalents;
    public bool hasFinishPickTalent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int CheckTalentTakenIndexByName(string talentName)
    {
        for(int i=0;  i<1;i++)
        {

            if (takenTalents[i].talentName == talentName)
                return i;
        }
        return -1;
    }
}
