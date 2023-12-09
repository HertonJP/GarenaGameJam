using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCheck : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform blade;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.eulerAngles = new Vector3(0, 0, 10);
        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x> transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, -180, 10);
        }
        else if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 10);
        }
    }
}
