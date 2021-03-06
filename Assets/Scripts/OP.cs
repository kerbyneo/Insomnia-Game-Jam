﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;

public class OP : MonoBehaviour
{
    public Sprite[] gallery; //store all your images in here at design time
    public Image displayImage; //The current image thats visible
    public Button nextImg; //Button to view next image
    public Button prevImg; //Button to view previous image
    public int i = 0; //Will control where in the array you are
    
    public GameObject nextScene;
    public GameObject nextButton;
    public GameObject prevButton;
    public AudioSource flipPage;


    public bool nextImage = false;

 
    public void BtnNext () {
        if(i + 1 < gallery.Length){
        i++;
        }
        flipPage.Play();
    }
 
    public void BtnPrev () {
        if(i > 0){
        i--;
        }
        flipPage.Play();
    }
 
    void Update () {
        /*if (transitionA < 1){
            transitionA += 0.08f;
            transition.color = new Color(1,1,1, transitionA);
        }
        */
        displayImage.sprite = gallery[i];

        if (i == 0){
            prevButton.SetActive(false);
        }else{
            prevButton.SetActive(true);
        }

        if(i < 19){
            nextButton.SetActive(true);
            nextScene.SetActive(false);
        }

        if(i == 19){
            nextScene.SetActive(true);
            nextButton.SetActive(false);
        }
        
    }
    /*
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
    */
}
