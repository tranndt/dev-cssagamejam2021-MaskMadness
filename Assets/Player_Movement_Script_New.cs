using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Script_New : MonoBehaviour
{

    private CharacterController controller;

    [SerializeField] float speed = 6f;
    [SerializeField] Transform playerCam;

    [SerializeField] float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3( horizontal , 0f, vertical ).normalized;

        if(direction.magnitude >= 0.1f)
        {   
            //Get the angle needed to rotate to face the direction we are moving
            //Imagine top down with axis X (left-right) and axis Z (front-back)
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCam.eulerAngles.y;

            //Smoothing angle instead of snapping to the correct angle right away
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity , turnSmoothTime );

            //Use Quaternion Euler angle to turn the player according to the Y axis.
            transform.rotation = Quaternion.Euler(0f, angle , 0f );

            //We also want to move to the camera direction as well
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //After we rotate the player, we move it.
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
