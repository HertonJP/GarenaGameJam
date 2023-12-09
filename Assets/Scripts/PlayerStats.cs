using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public int playerMaxHP = 100;
    public int playerHP;
    public int playerDamage = 10;
    public bool canBeDamaged = true;
    public TalentManager talentManager;
    private Coin coin;
    private Score score;
    public Image healthbar;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Manager").GetComponent<Score>();
        coin = GameObject.Find("Manager").GetComponent<Coin>();
        playerHP = playerMaxHP;
        healthbar.fillAmount = playerHP / playerMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (talentManager.takenTalents[0] != null && talentManager.CheckTalentTakenIndexByName("Immune") != -1)
        {
            GetComponent<Immune>().enabled = true;
        }
        if (playerHP <= 0)
        {
            playerHP = 0;
            coin.coin += score.score / 10;
            PlayerPrefs.SetInt("Coin", coin.coin);
            Invoke("Die", .5f);
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
    public void TakeDamage(int damageRecieved)
    {
        playerHP -= damageRecieved;
        healthbar.fillAmount = (float)playerHP / playerMaxHP;
    }
}
