using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    Vector3 position;
    public PlayerInfo playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="checkpoint")
        {
            position = transform.position;
            other.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    public void Respawn()
    {
        GetComponent<CharacterController>().enabled = false;
        transform.position = position;
        GetComponent<CharacterController>().enabled = true;
        playerInfo.SetHealth(3);
    }

    
}
