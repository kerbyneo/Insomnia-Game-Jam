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
    public float jumpHeight = 5f;
    public bool jumped;
    private float jumpGravity = 7;
    private float fallGravity = 5f;
    public bool releasedJump = true;
    public bool notColorAgain = false;
    public bool allColored = false;
    public bool moving = false;
    public SpriteRenderer thisSprite;
    private bool movingRight;
    public Transform checkpoint;
    public bool firstDie = false;
    public bool stillIn = false;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!colored || !allColored)
        {
            if (Input.GetKey(KeyCode.Space) && (feet.grounded) && releasedJump)
            {
                jumping = true;
                transform.Translate(0, 0, 0);
                releasedJump = false;
            }

            if (jumping)
            {
                if (Input.GetKeyUp(KeyCode.Space) || jumpcounter > jumpHeight + 3)
                {
                    thisRigidbody.gravityScale = fallGravity;
                    thisRigidbody.velocity = new Vector2(0, 0);
                    jumpcounter = 0;
                    jumping = false;
                }

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                releasedJump = true;
            }
        }

        if (moving && (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))){
                moving = false;
            }


            if (!movingRight)
            {
                if (thisSprite.flipX == false)
                {
                    thisSprite.flipX = true;
                }

            }
            else
            {
                if (thisSprite.flipX == true)
                {
                    thisSprite.flipX = false;
                }
            }
            if (moving)
            {
                if (colored)
                {
                    //colored walking animation
                    anim.SetBool("coloredrun", true);
                    anim.SetBool("running", false);
                    anim.SetBool("coloredidle", false);

                }
                else
                {
                    //white walking animation
                   anim.SetBool("running", true);
                   anim.SetBool("coloredrun", false);
                   anim.SetBool("coloredidle", false);
                }
            }
            else
            {
                if (colored)
                {
                    //colored idle animation
                    anim.SetBool("coloredidle", true);
                    anim.SetBool("coloredrun", false);
                    anim.SetBool("running", false);
                }
                else
                {
                    //white idle animation
                    anim.SetBool("running", false);
                    anim.SetBool("coloredrun", false);
                    anim.SetBool("coloredidle", false);
                }
            }

    }

    void FixedUpdate()
    {
        //jump

        if (jumping)
        {
            thisRigidbody.gravityScale = jumpGravity;

            //jumping animation
            anim.SetBool("jumping", true);
            jumpcounter += 1;

            int minusIdx = 100;
            if (jumpcounter > 8)
            {
                minusIdx = 110;
            }


            minusIdx = 80;
            if ((500 - jumpcounter * minusIdx)*Time.deltaTime >= 0)
            {
                thisRigidbody.AddForce(Vector2.up * (500 - jumpcounter * minusIdx) * Time.deltaTime, ForceMode2D.Impulse);
            }



            if (thisRigidbody.velocity.y > 40)
            {
                thisRigidbody.velocity = new Vector2(0, 40);
            }
            

        }
        else
        {
            thisRigidbody.gravityScale = fallGravity;
            //falling animation
            anim.SetBool("jumping", false);
            transform.Translate(0, 0, 0);
            jumpcounter = 0;
        }

        //moving
        if (!allColored)
        {
            if (colored)
            {
                movingSpd = 1;
            }
            else
            {
                movingSpd = 5;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-movingSpd * Time.deltaTime, 0, 0);
                moving = true;
                movingRight = false;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(movingSpd * Time.deltaTime, 0, 0);
                moving = true;
                movingRight = true;
            }

        }
        else
        {

            colored = false;
            moving = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!colored)
        {
            if (collision.gameObject.CompareTag("color"))
            {
                colored = true;
                stillIn = true;
            }
        }
        if (colored && notColorAgain)
        {
            if (collision.gameObject.CompareTag("color"))
            {
                allColored = true;
                firstDie = true;
                //death animation
                anim.SetBool("die", true);

                anim.SetBool("coloredrun", false);
                anim.SetBool("coloredidle", false);
                anim.SetBool("running", false);
                anim.SetBool("jumping", false);
            }
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (colored && collision.gameObject.CompareTag("color"))
        {
            notColorAgain = true;
            stillIn = false;
        }
    }

}
