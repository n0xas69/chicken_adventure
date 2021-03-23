using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreePoussin : MonoBehaviour
{
    GameObject cage;
    public Text infoText;
    AudioSource audiosource;
    public AudioClip poussin;
    bool canOpen;
    bool isPoussinHappy;


    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // si le joueur s'approche de la cage
        if (other.gameObject.tag == "cage")
        {
            cage = other.gameObject;
            infoText.text = "Appuyez sur E pour ouvrir la cage";
            canOpen = true;
            isPoussinHappy = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // quand le joueur s'éloigne de la cage
        if (other.gameObject.tag == "cage")
        {
            cage = null;
            infoText.text = "";
            canOpen = false;
            isPoussinHappy = false;
        }
    }

    private void Update()
    {
        // si le joueur appui sur E, on détrui les component de la cage
        if (Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            canOpen = false;
            pause.poussinRestant--;
            iTween.ShakeScale(cage, new Vector3(20, 20, 20), 1);
            Destroy(cage.GetComponent<MeshRenderer>(), 0.1f);
            Destroy(cage.GetComponent<BoxCollider>(), 0.1f);
            Destroy(cage.GetComponent<SphereCollider>(), 0.1f);
            infoText.text = "";
            if (isPoussinHappy)
                StartCoroutine("HappyPoussin");
        }
    }


    IEnumerator HappyPoussin()
    {
        yield return new WaitForSeconds(0.3f);
    
        audiosource.PlayOneShot(poussin);
        cage.transform.Find("Canvas").GetComponent<Canvas>().enabled = true;
        Destroy(cage.transform.Find("Canvas").gameObject, 1.3f);
        isPoussinHappy = false;
    }
}
