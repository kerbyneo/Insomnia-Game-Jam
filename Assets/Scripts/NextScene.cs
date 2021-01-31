using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    public string sceneToLoad;

    public void Next(){
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("next");
    }
}
