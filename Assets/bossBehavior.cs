using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehavior : MonoBehaviour
{
    public int counter = 0;
    public bool invincible = true;
    public int launchCounter = 0;
    public int skillCounter = 0;
    public bool markerBurst = false;
    public int markerBurstAngle = 200;
    public GameObject marker;
    public Transform left;
    public Transform right;
    public Transform top;
    public Transform bottom;
    public bool markerRain = false;
    public float xPos;
    public bool goDown = false;
    public bool orb = false;
    public float orbAngle = 0;
    public GameObject bullet;
    public Animator anim;
    public SpriteRenderer sr;
    public float a = 0;
    public bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        xPos = left.position.x;
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        gameObject.SetActive(false);
        sr.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (a < 1)
        {
            a += 0.05f;
            sr.color = new Color(1, 1, 1, a);
        }
        if (markerBurst)
        {
            markerRain = false;
            orb = false;
        }else if (markerRain)
        {
            markerBurst = false;
            orb = false;
        }else if (orb)
        {
            markerBurst = false;
            markerRain = false;
        }
    }

    void FixedUpdate()
    {
        if (move)
        {
            sr.enabled = true;
            counter += 1;
            if (invincible)
            {
                anim.SetBool("fade", false);
                anim.SetBool("fill", false);
                if (counter < 1000)
                {
                    launchCounter += 1;
                    if (launchCounter > 150)
                    {
                        float rand = Random.Range(0, 20);
                        if (rand < 10)
                        {
                            markerBurst = true;
                        }
                        else
                        {
                            markerRain = true;
                        }
                    }
                    if (markerBurst)
                    {
                        skillCounter += 1;
                        if (skillCounter > 15 && skillCounter < 17)
                        {
                            for (int i = 0; i < 12; i++)
                            {

                                float radians = (Mathf.PI / 180) * markerBurstAngle;
                                float thisX = 1 * Mathf.Sin(radians);
                                float thisY = 1 * Mathf.Cos(radians);
                                float newX = transform.position.x + thisX;
                                float newY = transform.position.y + thisY;
                                GameObject newMarker = Instantiate(marker, new Vector3(newX, newY, 0), Quaternion.Euler(0, 0, -markerBurstAngle + 90));
                                marker ifBurst = newMarker.GetComponent<marker>();
                                ifBurst.burstRotation = -markerBurstAngle + 90;
                                ifBurst.burst = true;

                                markerBurstAngle += 30;
                            }
                        }
                        else if (skillCounter > 200)
                        {
                            markerBurst = false;
                            skillCounter = 0;
                            markerBurstAngle = 0;
                            launchCounter = 0;
                        }
                    }
                    else if (markerRain)
                    {
                        skillCounter += 1;
                        if (skillCounter > 5 && xPos < right.position.x)
                        {
                            if (goDown)
                            {
                                GameObject thisMarker = Instantiate(marker, new Vector3(xPos, top.position.y, 0), Quaternion.Euler(0, 0, 0));
                                marker mScr = thisMarker.GetComponent<marker>();
                                mScr.burst = false;
                                mScr.rotate = -90;
                                goDown = false;
                            }
                            else
                            {
                                GameObject thisMarker = Instantiate(marker, new Vector3(xPos, bottom.position.y, 0), Quaternion.Euler(0, 0, 0));
                                marker mScr = thisMarker.GetComponent<marker>();
                                mScr.burst = false;
                                mScr.rotate = 90;
                                goDown = true;
                            }
                            xPos += 1.5f;
                            skillCounter = 0;
                        }
                        else if (skillCounter > 200)
                        {
                            skillCounter = 0;
                            markerRain = false;
                            launchCounter = 0;
                            xPos = left.position.x;
                        }
                    }
                }
                else
                {
                    counter = 0;
                    invincible = false;
                }
            }
            else
            {
                markerBurst = false;
                markerRain = false;
                if (counter < 200)
                {
                    anim.SetBool("fade", true);
                    anim.SetBool("fill", false);
                }
                else
                {
                    counter = 0;
                    invincible = true;
                    anim.SetBool("fill", true);
                    anim.SetBool("fade", false);
                }
            }
        }
        else
        {
            sr.color = new Color(1, 1, 1, 0);
            a = 0;
            xPos = left.position.x;
            sr.enabled = false;

        }
    }

}
