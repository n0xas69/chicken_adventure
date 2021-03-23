using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollition : MonoBehaviour
{
    AudioSource audiosource;
    public AudioClip hitSound;
    public AudioClip killSound;
    GameObject cam1;
    GameObject cam2;
    public GameObject splash;
    bool isInvincible = false;
    public SkinnedMeshRenderer rend;
    public PlayerInfo pi;
    public checkpoint check;


    private void Awake()
    {
        cam1 = GameObject.Find("cam_1");
        cam2 = GameObject.Find("cam_2");
        cam1.SetActive(false);
        cam2.SetActive(false);
    }

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        check = GetComponent<checkpoint>();
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "mob" && !isInvincible)
        {
            audiosource.PlayOneShot(hitSound);
            isInvincible = true;
            // on pousse le joueur en arrière
            iTween.PunchPosition(gameObject, Vector3.back * 2, .5f);

            StartCoroutine("ResetInvincible");
            pi.SetHealth(-1);
           
        }

        // si le joueur saute sur le monstre
        if (hit.gameObject.tag == "hurt")
        {
            // on désactive le collider du corps pour pas être touché le temps que le monstre disparaisse
            hit.gameObject.transform.Find("corps").GetComponent<BoxCollider>().enabled = false;
            hit.gameObject.GetComponent<BoxCollider>().enabled = false;
            iTween.PunchScale(hit.gameObject.transform.parent.gameObject, new Vector3(1.5f, 1.5f, 1.5f), .5f);
            Destroy(hit.gameObject.transform.parent.gameObject, .3f);
            audiosource.PlayOneShot(killSound);
            pause.ennemieRestant--;
        }

        // si le joueur touche l'eau
        if (hit.gameObject.tag == "fall")
        {

            Instantiate(splash, transform.position, Quaternion.identity);
            hit.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine("FallWater");

        }

        // si le jouru tombe dans le vide
        if (hit.gameObject.name == "Vide")
        {
            check.Respawn();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "camTrigger")
        {
            cam1.SetActive(true);
        }

        if (other.gameObject.name == "camTrigger2")
        {
            cam2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "camTrigger")
        {
            cam1.SetActive(false);
        }

        if (other.gameObject.name == "camTrigger2")
        {
            cam2.SetActive(false);
        }
    }

    IEnumerator ResetInvincible()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(.2f);
            rend.enabled = !rend.enabled;
        }
        yield return new WaitForSeconds(.2f);
        rend.enabled = true;
        isInvincible = false;
         
    }

    IEnumerator FallWater()
    {
        yield return new WaitForSeconds(1); 
        GameObject.Find("Cube.002").GetComponent<BoxCollider>().enabled = true;
        check.Respawn();
    }

}
