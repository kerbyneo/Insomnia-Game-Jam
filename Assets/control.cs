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
    public bool freeze;
    public bool inAir = false;
    public AudioSource nowPlaying;
    public AudioSource blue;
    public AudioSource red;
    public AudioSource boss;
    public bool fadeOut;
    public int fadeCounter = 0;
    public GameObject bossG;
    public AudioSource ambience;
    public gameManager manager;
    public bossBehavior bosscr;
    public int defeatCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        nowPlaying = blue;
        bosscr = bossG.GetComponent<bossBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bosscr.defeated)
        {
            defeatCounter += 1;
            StartCoroutine(Fadeout.startFade(nowPlaying, 2, 0));
        }

        if (nowPlaying == blue)
        {
            red.Stop();
            boss.Stop();
        }else if (nowPlaying == red)
        {
            blue.Stop();
            boss.Stop();
        }else if (nowPlaying == boss)
        {
            red.Stop();
            blue.Stop();
        }

        if (manager.mute)
        {
            StartCoroutine(Fadeout.startFade(nowPlaying, 2, 0));
            if (nowPlaying.volume == 0)
            {
                nowPlaying.Stop();
            }
        }
        else
        {
            nowPlaying.volume = 1;
            if (!nowPlaying.isPlaying)
            {
                nowPlaying.Play();
            }

        }

        if (!stillIn && colored)
        {
            notColorAgain = true;
        }

        


        if (fadeOut)
        {
            StartCoroutine(Fadeout.startFade(nowPlaying, 2, 0));
            fadeCounter += 1;
            if (fadeCounter > 5)
            {
                fadeOut = false;
            }
        }

        /*
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
                if (Input.GetKeyUp(KeyCode.Space) )
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
        */

        if (!colored)
        {

            if (Input.GetKeyDown(KeyCode.Space) && feet.grounded)
            {
                thisRigidbody.AddForce(Vector2.up * 16.5f, ForceMode2D.Impulse);
                anim.SetBool("jumping", true);
                jumping = true;
            }

            if (jumping && !feet.grounded)
            {
                inAir = true;
            }

            if (inAir && feet.grounded)
            {
                jumping = false;
                inAir = false;
                anim.SetBool("jumping", false);
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
        if (!colored)
        {
            /*
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
                if ((500 - jumpcounter * minusIdx) * Time.deltaTime >= 0)
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
        }
            */
        }
        //moving
        if (!allColored)
        {
            anim.SetBool("die", false);
            if (colored)
            {
                movingSpd = 2;
            }
            else
            {
                movingSpd = 5;
            }
            if (!freeze)
            {
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

        }
        else
        {
            colored = false;
            moving = false;
            //death animation
            anim.SetBool("die", true);

            anim.SetBool("coloredrun", false);
            anim.SetBool("coloredidle", false);
            anim.SetBool("running", false);
            anim.SetBool("jumping", false);
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
        if (collision.gameObject.CompareTag("check"))
        {
            checkpoint = collision.gameObject.transform;
        }
        if (colored && notColorAgain)
        {
            if (collision.gameObject.CompareTag("color"))
            {
                allColored = true;
                firstDie = true;

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "area1")
        {
            nowPlaying = blue;
            nowPlaying.volume = 1;
            fadeOut = false;
        }
        if (collision.gameObject.name == "area2")
        {
            nowPlaying = red;
            nowPlaying.volume = 1;
            fadeOut = false;
        }
        if (collision.gameObject.name == "area3")
        {
            nowPlaying = boss;
            fadeOut = false;
            nowPlaying.volume = 1;
            bossBehavior bosscr = bossG.GetComponent<bossBehavior>();
            bosscr.move = true;
            bossG.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (colored && collision.gameObject.CompareTag("color"))
        {
            notColorAgain = true;
            stillIn = false;

        }
        if (collision.gameObject.CompareTag("area"))
        {
            fadeOut = true;
        }
    }


    public static class Fadeout
    {
        public static IEnumerator startFade(AudioSource bgm, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = bgm.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                bgm.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }
    }


}
