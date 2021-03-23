using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnim : MonoBehaviour
{
    Vector3 dir;
    
    // Start is called before the first frame update
    void Start()
    {
        dir = new Vector3(0, 0, 115);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(dir * Time.deltaTime);
    }
}
