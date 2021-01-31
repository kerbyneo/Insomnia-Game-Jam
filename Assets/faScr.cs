using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faScr : MonoBehaviour
{
    public bool over = false;
    public SpriteRenderer sr;
    public bool next = false;
    public AudioSource blue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (over)
        {
            sr.color = new Color(1, 1, 1);
            if (Input.GetMouseButtonDown(0))
            {
                next = true;
                sr.enabled = false;
            }
        }
        else
        {
            sr.color = new Color(0, 0, 0);
        }
        if (!next)
        {

                blue.Stop();
        }
    }

    void OnMouseOver()
    {
        over = true;
    }
    void OnMouseExit()
    {
        over = false;
    }
}
