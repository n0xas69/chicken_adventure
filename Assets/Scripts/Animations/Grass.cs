using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{

    Vector3 amount;
    float time;

    private void OnTriggerEnter(Collider other)
    {
        // Si le nom du gameobject qui rentre en collision avec l'herbe est le joueur
        if (other.gameObject.name == "PlayerChicken")
        {
            makeAnim();
        }
    }

    void makeAnim()
    {
        amount = new Vector3(1.5f, 1.5f, 1.5f);
        time = 1;
        iTween.PunchScale(gameObject, amount, time);
    }


}
