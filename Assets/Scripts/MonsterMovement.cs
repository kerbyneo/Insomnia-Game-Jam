﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    //PURPOSE: control monster move in a distance
    //USAGE: put this on a monster object
    private Rigidbody2D rb;
    public Transform leftpoint, rightpoint; //distance limitation
    private bool Faceleft = true;
    public float Speed;
    public bool hit = true;
    public control scr;
    public BoxCollider2D box;
    public GameObject player;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        box = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player");
        scr = player.GetComponent<control>();
    }
   void Update()
    {
       Movement();
    }

    void Movement(){
        float randomNumber = Random.Range(5, 100); //random distance
        randomNumber = randomNumber - 1;
        if(Faceleft){
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            if(transform.position.x < leftpoint.position.x || randomNumber == 0 || hit){ //如果超过最左限制或者到达随机距离限制 掉头
                transform.localScale = new Vector3(-1, 1, 1);
                Faceleft = false;
                hit = false;
            }
        }else{
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            if (transform.position.x > rightpoint.position.x || randomNumber == 0 || hit){//如果超过最右限制或者到达随机距离限制 掉头
                transform.localScale = new Vector3(1, 1, 1);
                Faceleft = true;
                hit = false;
            }
        }
        if (!scr.allColored)
        {
            box.enabled = true;
        }
        else
        {
            box.enabled = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!scr.allColored)
            {
                hit = true;
            }
        }
    }

}
