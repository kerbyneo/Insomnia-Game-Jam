using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScr : MonoBehaviour
{
    public bool right = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (right)
        {
            transform.Translate(0.2f,0,0);
        }
        else
        {
            transform.Translate(-0.2f,0,0);
        }
    }
}
