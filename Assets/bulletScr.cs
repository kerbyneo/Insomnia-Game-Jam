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
    // Start is called before the first frame update
    void Start()
    {
        
        manager = GameObject.Find("Game Manager");
        player = GameObject.Find("Player");
        gm = manager.GetComponent<gameManager>();
        scr = player.GetComponent<control>();
        cir = GetComponent<CircleCollider2D>();
        
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
        counter += 1;
        if (counter > 500)
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
