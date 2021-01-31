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

                transform.position += transform.right * 0.1f;
                transform.rotation = Quaternion.Euler(0, 0, burstRotation);
                burstRotation -= 0.4f;
            }
            if (burstCounter > 200)
            {
                Destroy(gameObject);
            }
        }
    }
}
