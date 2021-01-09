using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_BOT_Script : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    private int wayPointIndex;
    private float distance;


    public float playerSpeed = 2.0f;


    private void Start()
    {        
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
