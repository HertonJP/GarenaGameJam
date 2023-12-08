using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float swordSwingSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.localEulerAngles = new Vector3(transform.localRotation.x, transform.localRotation.y, -Camera.main.ScreenToWorldPoint(Input.mousePosition).y * swordSwingSpeed);
    }
}
