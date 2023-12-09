using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Sword : MonoBehaviour
{
    public SwordDataSO swordData;
    public string swordName_ { get; private set; }
    public int swordDamage_ { get; private set; }

    private Vector3 lastMousePos;
    private Vector3 currMousePos;

    [SerializeField] private SpriteRenderer sr;

    [SerializeField] private TalentManager talentManager;

    private void Awake()
    {
       // Cursor.visible = false;
        sr = GetComponent<SpriteRenderer>();
        InitData();
    }

    private void Start()
    {
        currMousePos = Input.mousePosition;
    }

    private void Update()
    {
        if (Input.mousePosition != currMousePos)
        {
            GetComponent<Collider2D>().enabled = true;
            currMousePos = lastMousePos;
            currMousePos = Input.mousePosition;
        }else if(Input.mousePosition == currMousePos)
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (talentManager.takenTalents[0] != null && talentManager.CheckTalentTakenIndexByName("DoubleDamageChance") != -1)
            {
                GetComponent<Talent_DoubleDamageChance>().ImplementTalent(this);
            }
            if (talentManager.takenTalents[0] != null && talentManager.CheckTalentTakenIndexByName("Toxin") != -1)
            {
                GetComponent<Talent_Toxin>().targetEnemy = collision.GetComponent<Enemy>();
                GetComponent<Talent_Toxin>().enabled = true;
            }
            collision.GetComponent<Enemy>().TakeDamage(swordDamage_);
            Debug.Log("hits");
        }
    }
    
    public void SetSwordDamage(int newDamage)
    {
        swordDamage_ = newDamage;
    }

    private void InitData()
    {
        swordDamage_ = swordData.swordDamage;
        swordName_ = swordData.swordName;
        sr.sprite = swordData.swordSprite;
    }
}
