using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour
{
    public bossBehavior boss;
    public bool counter;
    public bool fall = false;
    public Rigidbody2D rb;
    public groundCheck feet;
    public Transform up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (!fall)
        {
            rb.isKinematic = true;
            transform.position = new Vector3(transform.position.x, up.position.y, 0);
        }
        else
        {
            if (!feet.grounded)
            {
                rb.isKinematic = false;
                rb.gravityScale = 10;
            }
            else
            {
                rb.isKinematic = true;
            }
        }
    }
}
