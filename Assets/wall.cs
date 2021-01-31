using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public control player;
    public BoxCollider2D box;
    public AudioSource hitWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.colored)
        {
            box.enabled = false;
        }
        else
        {
            box.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player"))
        {
            hitWall.Play();
        }

    }
}
