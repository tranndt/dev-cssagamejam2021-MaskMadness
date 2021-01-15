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
    [SerializeField] float carCurvative;
    

    // Start is called before the first frame update
    void Start()
    {   
        //Get the nodes on the path
        wayPoints = path.GetComponent<Path>().Get_Nodes();
        
        //Get the character controller for movement
        controller = gameObject.GetComponent<CharacterController>();

        //Set the default node index, but will be replace with the nearest one
        wayPointIndex = 0;
        float min =  Vector3.Distance(transform.position, wayPoints[0].position);

        //Find the nearest node to head to
        for(int i = 0; i < wayPoints.Length; i++)
        {
            distance = Vector3.Distance(transform.position, wayPoints[i].position);
            if (distance < min)
            {
                wayPointIndex = i;
                min = distance;
            }
        }

        //Make the car look at the nearest node
        transform.LookAt(wayPoints[wayPointIndex].position);

        //Set car speed
        carSpeed = 8f;

        //Set car curvative
        carCurvative = 3.5f;
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
    }

    private void MoveToPoint()
    {
        distance = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);

        Vector3 direction = wayPoints[wayPointIndex].position - transform.position;

        if (distance < 2f)
        {

            IncreaseIndex();
        }

        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, carCurvative * Time.deltaTime);

        Vector3 moveDir = transform.forward * carSpeed * Time.deltaTime;

        controller.Move(moveDir);
    }
}
