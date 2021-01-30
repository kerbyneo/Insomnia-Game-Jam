using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handkClick : MonoBehaviour
{
    Vector3 mousePosition;
    public bool follow;
    public Transform uiT;
    public bool availale = false;
    public bool clean;
    public control player;
    public GameObject left;
    public GameObject right;
    public Sprite uiS1;
    public Sprite uiS2;
    public SpriteRenderer uiS;
    public int counter = 0;
    public bool letGo = false;
    public bool spr2 = false;
    // Start is called before the first frame update
    void Start()
    {
        left.SetActive(false);
        right.SetActive(false);
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (counter < 60)
        {
            counter += 1;
        }
        else
        {
            counter = 70;
            letGo = true;
        }
    }

    void Update()
    {
        if (availale)
        {



            if (!player.stillIn && player.colored && letGo)
            {
                uiS.sprite = uiS2;
                spr2 = true;
            }
            else
            {
                uiS.sprite = uiS1;
                spr2 = false;
            }

            if (follow)
            {
                if (spr2)
                {
                    left.SetActive(true);
                }
                right.SetActive(true);
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(mousePosition.x, mousePosition.y, -10);
                if (Input.GetMouseButtonDown(1))
                {
                    follow = false;
                }
                if (clean && !player.stillIn)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (player.colored)
                        {
                            player.colored = false;
                            player.notColorAgain = false;
                            clean = false;
                            follow = false;
                        }
                    }
                }
            }
            else
            {
                left.SetActive(false);
                right.SetActive(false);
                transform.position = uiT.position;
            }
        }
    }

    void OnMouseOver()
    {
        if (availale)
        {
            if (Input.GetMouseButtonDown(0))
            {
                follow = true;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            clean = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            clean = false;
        }
    }

}
