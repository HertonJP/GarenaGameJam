using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour
{

    public GameObject talentPanel;
    public GameObject losePanel;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
        {
            Cursor.visible = false;
        }
        if(talentPanel.activeSelf || losePanel.activeSelf)
        {
            Cursor.visible = true;
        }
    }
}
