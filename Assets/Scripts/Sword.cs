using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
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

    [SerializeField] float coolDownTimer;
    [SerializeField] float currCoolDownTimer;

    [SerializeField] bool isOnCoolDown;

    [SerializeField] GameObject[] slashEffects;

    [SerializeField] CinemachineImpulseSource swordShakeSource;
    private void Awake()
    {
       // Cursor.visible = false;
        sr = GetComponent<SpriteRenderer>();
        InitData();
    }

    private void Start()
    {
        currMousePos = Input.mousePosition;
        currCoolDownTimer = coolDownTimer;
    }

    private void Update()
    {
        if (isOnCoolDown)
            currCoolDownTimer -= Time.deltaTime;

        if (currCoolDownTimer <= 0)
            isOnCoolDown = false;

        if (Input.mousePosition != currMousePos)
        {
            GetComponent<Collider2D>().enabled = true;
            currMousePos = lastMousePos;
            currMousePos = Input.mousePosition;

            
        }else if(Input.mousePosition == currMousePos)
        {
            
            GetComponent<Collider2D>().enabled = false;
            //Debug.Log("Disable Collider");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isOnCoolDown)
        {
            Debug.Log("hit");
            if (talentManager.takenTalents[0] != null && talentManager.CheckTalentTakenIndexByName("Bullet") != -1)
            {
                GetComponent<Talent_DoubleDamageChance>().ImplementTalent(this);
            }
            if (talentManager.takenTalents[0] != null && talentManager.CheckTalentTakenIndexByName("Toxin") != -1)
            {
                GetComponent<Talent_Toxin>().targetEnemy = collision.GetComponent<Enemy>();
                GetComponent<Talent_Toxin>().enabled = true;
            }
            for(int i=0; i<slashEffects.Length; i++)
            {
                Instantiate(slashEffects[Random.Range(0, 4)], collision.transform.position,Quaternion.identity);
            }
            collision.GetComponent<Enemy>().TakeDamage(swordDamage_);
            currCoolDownTimer = coolDownTimer;
            isOnCoolDown = true;
            
            swordShakeSource.GenerateImpulse();
            swordDamage_ = swordData.swordDamage;
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
