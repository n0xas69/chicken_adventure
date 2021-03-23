using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    AudioSource audiosource;
    public AudioClip sound;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        StartCoroutine("PlayGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator PlayGame()
    {
        audiosource.PlayOneShot(sound);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
