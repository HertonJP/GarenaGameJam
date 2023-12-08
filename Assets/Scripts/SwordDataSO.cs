using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SwordData", menuName = "New Sword Data")]
public class SwordDataSO : ScriptableObject
{
    public string swordName;
    public float swordDamage;
    public Sprite swordSprite;
}
