using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public bool colored = false;
    public int movingSpd = 8;
    public bool jumping = false;
    public bool falling = false;
    public groundCheck feet;
    public Rigidbody2D thisRigidbody;
    public int jumpcounter = 0;
    public float jumpHeight = 1.5f;
    public bool jumped;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && (feet.grounded) && !jumped)
        {
            jumping = true;
            transform.Translate(0, 0, 0);
        }

        if (jumping)
        {
            if (Input.GetKeyUp(KeyCode.Space) || jumpcounter > jumpHeight + 3)
            {
                thisRigidbody.velocity = new Vector2(0, 0);
                jumpcounter = 0;
                jumping = false;
                jumped = false;
            }
        }
    }

    void FixedUpdate()
    {
        //jump


        if (jumping)
        {

            if (!feet.grounded)
            {
                jumped = true;
            }

            //jumping animation
            jumpcounter += 1;

            int minusIdx = 100;
            if (jumpcounter > 8)
            {
                minusIdx = 110;
            }


            minusIdx = 80;
            thisRigidbody.AddForce(Vector2.up * (400 - jumpcounter * minusIdx) * Time.deltaTime, ForceMode2D.Impulse);



            if (thisRigidbody.velocity.y > 40)
            {
                thisRigidbody.velocity = new Vector2(0, 40);
            }
            

        }
        else
        {
            //falling animation
            transform.Translate(0, 0, 0);
            jumpcounter = 0;
        }
        //moving
        if (colored)
        {
            movingSpd = 3;
        }
        else
        {
            movingSpd = 8;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-movingSpd * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(movingSpd * Time.deltaTime, 0, 0);
        }
    }
}
