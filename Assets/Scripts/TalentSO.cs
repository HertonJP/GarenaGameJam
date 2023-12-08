using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Talent SO", menuName = "Create New Talent")]
public class TalentSO : ScriptableObject
{
    public Sprite talentSprite;
    public string talentName;
    public string talentDescription;
    public IImplementTalent talentLogic;
}
