using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private string WALK_ANIM = "isWalking";
    private string RUN_ANIM = "isRunning";
    [SerializeField] CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Animator animator;

    [SerializeField] float value;

    private void Start()
    {
        //controller = gameObject.AddComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {   
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move.y = 0;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool(RUN_ANIM, true);
            playerSpeed = 6f;
        }
        else
        {
            animator.SetBool(RUN_ANIM, false);
        }

        if (move != Vector3.zero)
        {
            animator.SetBool(WALK_ANIM, true);
            gameObject.transform.forward = move;
        }
        else
        {   
            animator.SetBool(WALK_ANIM, false);
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == 15)
        {
            Debug.Log("Mask picked up");
            FindObjectOfType<AudioManager>().Play("pickup");
            GameObject mask_object = collider.gameObject;
            if(mask_object != null)
            {
                var mask = mask_object.GetComponent<Mask_Attributes>();
                value += mask.Get_Value();
            }
            
            Destroy(collider.gameObject);
        }
    }
}