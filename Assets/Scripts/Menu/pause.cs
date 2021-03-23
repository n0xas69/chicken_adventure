using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{

    bool isPause = false;
    public GameObject menuPause;
    public Text objectifs;
    public Text warning;
    public Text enfText;
    public static int poussinRestant = 3;
    public static int ennemieRestant = 2;

    void Setobjectifs()
    {
        objectifs.text = "- Il reste " + poussinRestant + " poussins à libérer.\n- Il reste " + ennemieRestant + " monstre à tuer";
    }

   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause)
            {
                isPause = false;
                menuPause.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                Setobjectifs();
                isPause = true;
                menuPause.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
