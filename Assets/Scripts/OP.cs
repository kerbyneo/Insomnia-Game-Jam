﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class OP : MonoBehaviour
{
    public Sprite[] gallery; //store all your images in here at design time
    public Image displayImage; //The current image thats visible
    public Button nextImg; //Button to view next image
    public Button prevImg; //Button to view previous image
    public int i = 0; //Will control where in the array you are

    public bool nextImage = false;

    //public float transitionA = 0;
    //public SpriteRenderer transition;


 
    public void BtnNext () {
        if(i + 1 < gallery.Length){
        i++;
        }
    }
 
    public void BtnPrev () {
        if(i - 1 > 0){
        i--;
        }
    }
 
    void Update () {
        /*if (transitionA < 1){
            transitionA += 0.08f;
            transition.color = new Color(1,1,1, transitionA);
        }
        */
        if (nextImage == true){
            displayImage.sprite = gallery[i];
        }
        
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        if(Input.GetMouseButtonDown(0)){
            nextImage = true;
            if(i + 1 < gallery.Length){
            i++;
            }
        }
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        nextImage = false;
    }
    
}