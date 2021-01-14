using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_AI : MonoBehaviour
{
    [SerializeField] GameObject path;
    private Transform[] wayPoints;
    private int wayPointIndex;
    private float distance;
    private CharacterController controller;
    [SerializeField] float carSpeed;

    // Start is called before the first frame update
    void Start()
    {
        wayPoints = path.GetComponentsInChildren<Transform>();
        controller = gameObject.GetComponent<CharacterController>();

        wayPointIndex = 0;
        float min =  Vector3.Distance(transform.position, wayPoints[0].position);

        for(int i = 0; i < wayPoints.Length; i++)
        {
            distance = Vector3.Distance(transform.position, wayPoints[i].position);
            if (distance < min)
            {
                wayPointIndex = i;
                min = distance;
            }
        }

        transform.LookAt(wayPoints[wayPointIndex].position);
        carSpeed = 8f;
    }

    // Update is called once per frame
    void Update()
    {   
        MoveToPoint();
    }

    private void IncreaseIndex()
    {
        wayPointIndex++;
        if (wayPointIndex >= wayPoints.Length)
        {
            wayPointIndex = 0;
        }
        //transform.LookAt(wayPoints[wayPointIndex].position);
    }

    private void MoveToPoint()
    {
        distance = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);

        if (distance < 1f)
        {
            PerformTurn();
            IncreaseIndex();
            return;
        }

        Vector3 moveDiff = wayPoints[wayPointIndex].position - transform.position;
        Vector3 moveDir = moveDiff.normalized * carSpeed * Time.deltaTime;

        controller.Move(moveDir);
    }

    private void PerformTurn()
    {
        Vector3 currEdge;
        Vector3 nextEdge;
        if (wayPoints.Length > 2)
        {
            currEdge = wayPoints[(wayPointIndex + 1) % wayPoints.Length].position - wayPoints[wayPointIndex % wayPoints.Length].position;
            nextEdge = wayPoints[(wayPointIndex + 2) % wayPoints.Length].position - wayPoints[(wayPointIndex + 1) % wayPoints.Length].position;

            float angle = Vector3.Angle(currEdge, nextEdge);
            Debug.Log(angle);
            transform.rotation = Quaternion.Euler(0f, -angle, 0f);

        }
        else
        {
            return;
        }

    }
}
