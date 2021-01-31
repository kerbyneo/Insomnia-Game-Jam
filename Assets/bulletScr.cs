using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScr : MonoBehaviour
{
    public bool right = false;
    public int counter = 0;
    public GameObject player;
    public control scr;
    public gameManager gm;
    public CircleCollider2D cir;
    public GameObject manager;
    public bool bossUse = false;
    public float rotate;
    public float a = 0;
    public SpriteRenderer sr;
    public float r;
    public float g;
    public float b;
    public bool rotated = false;
    // Start is called before the first frame update
    void Start()
    {
        
        manager = GameObject.Find("Game Manager");
        player = GameObject.Find("Player");
        gm = manager.GetComponent<gameManager>();
        scr = player.GetComponent<control>();
        cir = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        r = sr.color.r;
        g = sr.color.g;
        b = sr.color.b;
        sr.color = new Color(r, g, b, a);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (counter < 100)
        {
            if (bossUse)
            {
                if (!rotated)
                {
                    transform.rotation = Quaternion.Euler(0, 0, rotate);
                    rotated = true;
                }
                if (a < 1)
                {
                    a += 0.05f;
                    sr.color = new Color(r, g, b, a);
                }
            }
            else
            {
                a = 1;
                sr.color = new Color(r, g, b, a);
            }
        }
        if (right)
        {
            transform.position += transform.right * 0.2f;
        }
        else
        {
            transform.position -= transform.right * 0.2f;
        }
        counter += 1;
        if (counter > 100)
        {
            if (a > 0)
            {
                a -= 0.1f;
                sr.color = new Color(r, g, b, a);
            }
        }
        if (counter > 200)
        {
            Destroy(gameObject);
        }
        if (!gm.pause)
        {
            if (scr.allColored)
            {
                cir.enabled = false;
            }
        }
    }
}
