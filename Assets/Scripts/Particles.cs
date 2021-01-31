using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class Particles : MonoBehaviour
{
    public ParticleSystem triangle;
    public bool playTri = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!triangle.isPlaying){
            triangle.Play();
            playTri = true;
        }
        
    }
}
