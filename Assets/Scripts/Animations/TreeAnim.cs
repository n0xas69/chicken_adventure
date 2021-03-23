using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnim : MonoBehaviour
{
    Vector3 ammount;
    float time;
    
    // Start is called before the first frame update
    void Start()
    {
        time = 4;
        float randomTime = Random.Range(time - 0.3f, time + 0.3f);
        ammount = new Vector3(1, 1, 1);
        iTween.PunchRotation(gameObject, iTween.Hash(
                "amount", ammount,
                "time", randomTime,
                "looptype", iTween.LoopType.loop
            ));
    }

 
}
