using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public int score = 0;
    public TextMeshProUGUI scoreTMP;
    // Start is called before the first frame update
    void Start()
    {
        scoreTMP.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTMP.text = "Score: " + score.ToString();
    }

    
}
