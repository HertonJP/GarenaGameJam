using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public SwordDataSO swordData;
    public float swordDamage_ { get; private set; }
    public string swordName_ { get; private set; }
    private SpriteRenderer sr;
    private void Awake()
    {
        Cursor.visible = false;
        sr = GetComponent<SpriteRenderer>();
        InitData();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("hits");
        }
    }

    public void SetSwordDamage(float newDamage)
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
