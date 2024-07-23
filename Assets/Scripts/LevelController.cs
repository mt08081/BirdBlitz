using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public float levelSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move level in the 2d direction backwards by some points each frame
        transform.Translate(Vector3.left*levelSpeed * Time.deltaTime);
    }
}
