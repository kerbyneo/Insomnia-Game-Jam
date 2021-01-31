using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreditMenu : MonoBehaviour
{
    public GameObject creditPanal;
    
    public void OpenCredit(){
        if(creditPanal !=null){
            creditPanal.SetActive(true);
        }
        
    }

    public void CloseCredit(){
        creditPanal.SetActive(false);
        Debug.Log("turn off");
    }
}
