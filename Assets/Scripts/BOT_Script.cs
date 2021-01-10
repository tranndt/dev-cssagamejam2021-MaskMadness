using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOT_Script : MonoBehaviour
{
    private string RUN_ANIM = "isRunning";
    private string WALK_ANIM = "isWalking";
    private string BITE_ANIM = "isBitable";
    [SerializeField] Transform[] wayPoints;
    private Transform target;
    private float target_distance;
    public float detect_range;
    private bool isChasing;

    private int wayPointIndex;
    private float distance;

    //[SerializeField] CharacterController controller;

    public float playerSpeed = 2.0f;
    private Animator animator;

    private void Start()
    {   
        //Get the transform of the player
        target = GameObject.FindGameObjectWithTag("Player").transform;
        detect_range = 8f;
        isChasing = false;

        animator = GetComponent<Animator>();
        wayPointIndex = 0;
        transform.LookAt(wayPoints[wayPointIndex].position);
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);

        Detection();

        if (!isChasing)
        {
            if (distance < 1f)
            {
                IncreaseIndex();
            }
            Patrol();
        }

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

    private void Detection()
    {
        target_distance = Vector3.Distance(target.position, transform.position);
        if(target_distance <= detect_range)
        {
            isChasing = true;
            if (target_distance <= 1.3)
            {
                In_Range_Bite(target_distance);
                if (!FindObjectOfType<AudioManager>().isPlaying("nomnom"))
                {
                    FindObjectOfType<AudioManager>().Play("nomnom");
                }
            }
            else
            {
                transform.LookAt(target);
                animator.SetBool(BITE_ANIM, false);
                animator.SetBool(RUN_ANIM, true);
                transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
            }
        }
        else
        {
            isChasing = false;
            animator.SetBool(BITE_ANIM, false);
        }

    }



    private void In_Range_Bite(float target_distance)
    {
       animator.SetBool(BITE_ANIM, true);
    }


}
