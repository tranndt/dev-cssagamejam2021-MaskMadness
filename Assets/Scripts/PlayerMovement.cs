using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private string RUN_ANIM = "isRunning";
    private string WALK_ANIM = "isWalking";
        
    private Animator animator;
    private CharacterController controller;

    private float playerSpeed = 2.0f;


    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {


        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            animator.SetBool(WALK_ANIM, true);
            gameObject.transform.forward = move;
        }
        else
        {
            animator.SetBool(WALK_ANIM, false);
        }
    }
}