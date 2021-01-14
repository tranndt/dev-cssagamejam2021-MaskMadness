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
        transform.LookAt(wayPoints[wayPointIndex].position);
        carSpeed = 8f;
    }

    // Update is called once per frame
    void Update()
    {   
        MoveToPoint();
        Debug.Log(wayPointIndex);
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

    private void MoveToPoint()
    {
        distance = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);

        if (distance < 1f)
        {
            Debug.Log("CALLED");
            IncreaseIndex();
            return;
        }

        Vector3 moveDiff = wayPoints[wayPointIndex].position - transform.position;
        Vector3 moveDir = moveDiff.normalized * carSpeed * Time.deltaTime;

        controller.Move(moveDir);
    }
}
