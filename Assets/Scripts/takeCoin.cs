using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeCoin : MonoBehaviour
{
    
    public GameObject pickupEffect;
    public AudioClip sound;
    AudioSource audiosource;
    public PlayerInfo pi;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            GameObject go = Instantiate(pickupEffect, transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
            Destroy(other.gameObject);
            audiosource.PlayOneShot(sound);
            pi.GetCoin();
        }
    }
}
