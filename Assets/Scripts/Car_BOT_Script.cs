using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_BOT_Script : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    private int wayPointIndex;
    private float distance;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] CharacterController controller;
    private float gravityValue = -9.81f;

    public float playerSpeed = 2.0f;

    private void Start()
    {        
        wayPointIndex = 0;
        transform.LookAt(wayPoints[wayPointIndex].position);
    }

    void Update()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        distance = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);

        if (distance < 1f)
        {
            IncreaseIndex();
        }
        Patrol();

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


    private void Patrol()
    {
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
