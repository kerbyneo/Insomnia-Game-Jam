using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public void Exit(){
        Application.Quit();
        Debug.Log("Quit");
    }
}
