using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] OP oP;
    public float transitionA = 0;
    public SpriteRenderer transition;

    // Update is called once per frame
    void Update()
    {
        if(oP.nextImage == true){
            if (transitionA < 1){
                transitionA += 0.08f;
                transition.color = new Color(1,1,1, transitionA);
            }
        }  
    }
}
