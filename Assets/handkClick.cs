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
    // Start is called before the first frame update
    void Start()
    {
        left.SetActive(false);
        right.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (availale)
        {
            if (!player.stillIn && player.colored)
            {
                uiS.sprite = uiS2;
            }
            else
            {
                uiS.sprite = uiS1;
            }

            if (follow)
            {
                left.SetActive(true);
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
