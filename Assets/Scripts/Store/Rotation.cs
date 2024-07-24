using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float rotationspeed=50f;

    // Update is called once per frame
    void FixedUpdate() 
    {
        transform.Rotate(0, rotationspeed* Time.deltaTime,0);
    }
}
