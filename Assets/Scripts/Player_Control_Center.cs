//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Player_Control_Center : MonoBehaviour
//{
//    [SerializeField] float speed = 6f;
//    [SerializeField] float run_speed = 10f;

//    //horizontal = left to right (-1, 0 , 1)
//    //vertical = up to down (-1, 0 , 1)
//    float horizontal;
//    float vertical;
//    private Player_Movement_Script_New player_movement;
//    //private Player_Animation_Fix player_animator;

//    // Start is called before the first frame update
//    void Start()
//    {
//        player_movement = (Player_Movement_Script_New) gameObject.GetComponent(typeof(Player_Movement_Script_New));
//        //player_animator = (Player_Animation_Fix) gameObject.GetComponent(typeof(Player_Animation_Fix));
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //Get the movement input values
//        horizontal = Input.GetAxisRaw("Horizontal");
//        vertical = Input.GetAxisRaw("Vertical");

//        if (horizontal != 0 || vertical != 0)
//        {
//            player_movement.MovePlayer(speed);
//        }


//        if (horizontal != 0 && vertical == 0)
//        {
//            if (horizontal == -1)
//            {
//                player_animator.Play_Left_Walk_Anim();
//            }else if(horizontal == 1)
//            {
//                player_animator.Play_Right_Walk_Anim();
//            }
//        }else if (horizontal != 0 || vertical != 0)
//        {
//            player_animator.Play_Walk_Anim();
//        }

//        if (horizontal == 0 && vertical == 0)
//        {
//            player_animator.Play_Idle_Anim();
//        }
//    }
//}
