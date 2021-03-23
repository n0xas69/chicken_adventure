using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashSound : MonoBehaviour
{

    AudioSource audiosource;
    public AudioClip sound;


    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "fall")
        {
            audiosource.PlayOneShot(sound);
        }
    }

}
