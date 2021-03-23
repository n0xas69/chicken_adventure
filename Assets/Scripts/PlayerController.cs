using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController cc;
    float moveSpeed;
    public float forceJump;
    public float gravity;
    Vector3 direction;
    Animator anim;
    bool isWalking;
    bool isRunning;

    // Update is called once per frame

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), direction.y, Input.GetAxis("Vertical"));
        
        //saut
        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        {
            direction.y = forceJump;
        }

        // si le joueur bouge
        if(direction.x != 0 || direction.z != 0)
        {
            // si le joueur appui sur shift, il court plus vite
            if(Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = 7;
                isWalking = false;
                isRunning = true;
            }
            else
            {
                moveSpeed = 5;
                isRunning = false;
                isWalking = true;
                
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)), 0.10f);

        }
        else
        {
            isRunning = false;
            isWalking = false;

        }


        anim.SetBool("Walk", isWalking);
        anim.SetBool("Run", isRunning);

      
        direction.y -= gravity * Time.deltaTime;
        cc.Move(direction * moveSpeed * Time.deltaTime);
    }
}
