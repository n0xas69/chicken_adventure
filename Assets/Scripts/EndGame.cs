using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public pause pause;
    AudioSource audiosource;
    public AudioClip sound;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (pause.poussinRestant == 0 && pause.ennemieRestant == 0)
            {
                StartCoroutine("EndOfGame");
            }
            else
            {
                pause.warning.text = "Il vous reste des objectifs à atteindre !";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pause.warning.text = "";
        }
    }

    IEnumerator EndOfGame()
    {
        audiosource.PlayOneShot(sound);
        yield return new WaitForSeconds(1);
        pause.enfText.text = "Bravo vous avez finit le jeu";
    }
}


