using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehavior : MonoBehaviour
{
    public int counter = 0;
    public bool invincible = true;
    public int launchCounter = 0;
    public int skillCounter = 0;
    public bool markerBurst = true;
    public int markerBurstAngle = 200;
    public GameObject marker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        counter += 1;
        if (invincible)
        {
            if (counter < 1000)
            {
                launchCounter += 1;
                if (launchCounter > 300)
                {
                    float rand = Random.Range(0, 30);
                    if (rand < 10)
                    {
                        markerBurst = true;
                    }
                    launchCounter = 0;
                }
                if (markerBurst)
                {
                    skillCounter += 1;
                    if (skillCounter > 15 && skillCounter < 17)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            if (i <= 9 && i >= 4)
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
                            }
                            markerBurstAngle += 30;
                        }
                    }else if (skillCounter > 200)
                    {
                        markerBurst = false;
                        skillCounter = 0;
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
            if (counter < 300)
            {

            }
            else
            {
                counter = 0;
                invincible = true;
            }
        }
    }

}
