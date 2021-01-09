using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOT_Script : MonoBehaviour
{
    private string RUN_ANIM = "isRunning";
    [SerializeField] Transform[] wayPoints;
    private int wayPointIndex;
    private float distance;

    //    animator = GetComponent<Animator>();
    [SerializeField] CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private Animator animator;

    private void Start()
    {
        //controller = gameObject.AddComponent<CharacterController>();
        animator = GetComponent<Animator>();
        wayPointIndex = 0;
        transform.LookAt(wayPoints[wayPointIndex].position);
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);

        if (distance < 1f)
        {
            IncreaseIndex();
        }
        Patrol();
        //Move_BOT(distance);
    }

    public void Move_BOT()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            animator.SetBool(RUN_ANIM, true);
            gameObject.transform.forward = move;
        }
        else
        {
            animator.SetBool(RUN_ANIM, false);
        }
    }

    private void Patrol()
    {
        animator.SetBool(RUN_ANIM, true);
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
    }

    private void IncreaseIndex()
    {
        wayPointIndex++;
        if (wayPointIndex >= wayPoints.Length)
        {
            wayPointIndex = 0;
        }
        transform.LookAt(wayPoints[wayPointIndex].position);
    }
}
