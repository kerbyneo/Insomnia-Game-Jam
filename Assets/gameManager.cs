﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public control player;
    public bool pause = false;
    public int startCounter = 0;
    public int pauseCounter = 0;
    public int fadeCounter = 0;
    public SpriteRenderer bed;
    public SpriteRenderer room;
    public GameObject playerG;
    public int getToPause = 0;
    public float roomA = 1;
    public int duration = 200;
    public SpriteRenderer recall;
    public SpriteRenderer handk;
    public SpriteRenderer ui;
    public float recallA = 0;
    public float handkA = 0;
    public float uiA = 0;
    public Transform uiT;
    public Transform handkT;
    public bool first = true;
    public int handkCounter = 0;
    public handkClick handkScr;
    public faScr fa;
    public GameObject bossG;
    public bool mute = false;
    public AudioSource ambience;
    public Sprite newRoom;
    public bool dead;
    public bossBehavior bosscr;
    public falling fall2;
    // Start is called before the first frame update
    void Start()
    {
        
        ambience.volume = 0;
        recall.color = new Color(1, 1, 1, recallA);
        handk.color = new Color(1, 1, 1, handkA);
        ui.color = new Color(1, 1, 1, uiA);
        bosscr = bossG.GetComponent<bossBehavior>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!bosscr.defeated)
        {
            if (player.allColored)
            {
                if (!pause)
                {
                    startCounter = 0;
                }
                getToPause += 1;
                if (getToPause > 200)
                {
                    pause = true;

                    player.allColored = false;
                }
            }

            if (first)
            {
                duration = 800;
            }
            else
            {
                duration = 200;
            }

            if (pause)
            {

                fadeCounter += 1;
                if (fadeCounter > duration)
                {
                    getToPause = 0;
                    startCounter += 1;
                }
                else
                {
                    startCounter = 0;
                    if (roomA < 1)
                    {
                        mute = true;
                        ambience.volume = 1;
                        ambience.Play();
                        roomA += 0.2f;
                    }
                    else
                    {
                        player.freeze = true;
                        dead = true;
                        fall2.fall = false;
                    }
                    room.color = new Color(1, 1, 1, roomA);
                    if (first)
                    {
                        if (fadeCounter > 250 && fadeCounter < 500)
                        {
                            if (recallA < 1)
                            {
                                recallA += 0.05f;
                                recall.color = new Color(1, 1, 1, recallA);
                            }
                            else
                            {
                                if (handkA < 1)
                                {
                                    handkA += 0.08f;
                                    handk.color = new Color(1, 1, 1, handkA);
                                    uiA += 0.08f;
                                    ui.color = new Color(1, 1, 1, uiA);
                                }
                                else
                                {
                                    handkCounter += 1;
                                    if (handkCounter > 30)
                                    {
                                        Vector3 targetPosition = uiT.position;
                                        Vector3 smoothedPosition = Vector3.Lerp(handkT.position, targetPosition, 1.5f * Time.deltaTime);
                                        handkT.position = smoothedPosition;
                                    }
                                }
                            }
                        }
                        else if (fadeCounter > 500 && fadeCounter < 600)
                        {
                            if (recallA > 0)
                            {
                                recallA -= 0.05f;
                                recall.color = new Color(1, 1, 1, recallA);
                            }
                        }
                        else if (fadeCounter > 600)
                        {
                            first = false;
                            handkScr.availale = true;
                        }
                    }
                }
            }
            if (fa.next)
            {
                if (!player.firstDie)
                {
                    startCounter += 1;
                }

            }
            else
            {
            }

            if (startCounter > 50)
            {
                if (roomA > 0)
                {
                    roomA -= 0.02f;
                    StartCoroutine(Fadeout.startFade(ambience, 2, 0));
                    mute = false;
                }
                else
                {
                    room.sprite = newRoom;
                    dead = false;
                }
                player.freeze = false;
                room.color = new Color(1, 1, 1, roomA);
                if (startCounter > 51 && startCounter < 53)
                {
                    playerG.transform.position = player.checkpoint.position;
                    bossBehavior bosscr = bossG.GetComponent<bossBehavior>();
                    bosscr.move = false;
                    player.colored = false;
                    player.allColored = false;
                    player.notColorAgain = false;


                }
            }
            else
            {

            }


            if (startCounter > 100)
            {

                getToPause = 0;
                player.allColored = false;
                if (startCounter > 101 && startCounter < 103)
                {


                    pauseCounter = 0;
                    fadeCounter = 0;
                    getToPause = 0;
                    roomA = 0;
                    fadeCounter = 0;
                    pause = false;
                    if (first == false)
                    {
                        room.sortingOrder = 500;
                    }

                }
            }
        }

    }


    public static class Fadeout
    {
        public static IEnumerator startFade(AudioSource bgm, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = bgm.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                bgm.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }
    }


    IEnumerator FadeToBed()
    {
        Color color = bed.material.color;
        while (color.a > 0)
        {
            color.a -= 0.7f * Time.deltaTime;
            bed.material.color = color;
            yield return null;
        }

    }

    IEnumerator FadeToRoom()
    {
        Color roomC = room.material.color;
        while (roomC.a > 0)
        {
            roomC.a -= 0.5f * Time.deltaTime;
            room.material.color = roomC;
            yield return null;
        }
    }

    IEnumerator FadeOutBed()
    {
        Color color = bed.material.color;
        while (color.a < 255)
        {
            color.a += 2f * Time.deltaTime;
            bed.material.color = color;
            yield return null;
        }

    }

    IEnumerator FadeOutRoom()
    {
        Color roomC = room.material.color;
        while (roomC.a < 255)
        {
            roomC.a += 2f * Time.deltaTime;
            room.material.color = roomC;
            yield return null;
        }
    }

}
