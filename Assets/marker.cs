using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marker : MonoBehaviour
{
    public bool burst = false;
    public int burstCounter = 0;
    public float burstRotation = 0;
    public SpriteRenderer spr;
    public float a = 0;
    public float rotate = 0;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.color = new Color(1, 1, 1, a);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (spr.color.a < 1)
        {
            a += 0.05f;
            spr.color = new Color(1, 1, 1, a);
        }
        if (burst)
        {
            burstCounter += 1;
            if (burstCounter > 40)
            {

                transform.position += transform.right * 0.3f;
                transform.rotation = Quaternion.Euler(0, 0, burstRotation);
                burstRotation -= 0.4f;
            }
            if (burstCounter > 200)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            burstCounter += 1;
            if (burstCounter > 40)
            {

                transform.position += transform.right * 0.5f;
                transform.rotation = Quaternion.Euler(0, 0, rotate);
                burstRotation -= 0.4f;
            }
            if (burstCounter > 100)
            {
                Destroy(gameObject);
            }
        }
    }
}
