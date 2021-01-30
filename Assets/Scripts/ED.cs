using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class ED : MonoBehaviour
{
   public Sprite[] gallery; //store all your images in here at design time
    public Image displayImage; //The current image thats visible
    public Button nextImg; //Button to view next image
    public Button prevImg; //Button to view previous image
    public int i = 0; //Will control where in the array you are
    
    public GameObject nextButton;
    public GameObject prevButton;

    public bool nextImage = false;
 
    public void BtnNext () {
        if(i + 1 < gallery.Length){
        i++;
        }
    }
 
    public void BtnPrev () {
        if(i > 0){
        i--;
        }
    }
 
    void Update () {
        displayImage.sprite = gallery[i];

        if (i == 0){
            prevButton.SetActive(false);
        }else{
            prevButton.SetActive(true);
        }

        if(i < 5){
            nextButton.SetActive(true);
        } else {
            nextButton.SetActive(false);
        }
        
    }
}
