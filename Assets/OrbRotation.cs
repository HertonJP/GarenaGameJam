using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbRotation : MonoBehaviour
{
    private float currRot = 0;
    [SerializeField] private float rotSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currRot += rotSpeed;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, currRot);
    }
}
