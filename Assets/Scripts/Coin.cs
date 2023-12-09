using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int coin;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("Coin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
