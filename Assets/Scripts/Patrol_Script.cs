using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Patrol_Script : MonoBehaviour
{
    private string RUN_ANIM = "isRunning";
    private string WALK_ANIM = "isWalking";
    [SerializeField] Transform[] wayPoints;
    private System.Random rnd = new System.Random();


    private int wayPointIndex;
    private float distance;

    //[SerializeField] CharacterController controller;

    public float playerSpeed = 2.0f;
    private Animator animator;

    private void Start()
    { 
        playerSpeed = rnd.Next(2, 35);
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
    }

    private void Patrol()
    {
        animator.SetBool(WALK_ANIM, true);
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
