using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bullet;
    public int counter;
    public bool right;
    public int speed = 70;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += 1;
        if (counter > speed)
        {
            GameObject newBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
            bulletScr scr = newBullet.GetComponent<bulletScr>();
            if (right)
            {
                scr.right = true;
            }
            else
            {
                scr.right = false;
            }
            counter = 0;
        }
    }
}
