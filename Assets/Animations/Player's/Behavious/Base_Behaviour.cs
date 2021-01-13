using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Behaviour : StateMachineBehaviour
{
    //Input axis
    protected float horizontal;
    protected float vertical;

    //speeds
    protected float speed;
    protected float walk_speed = 2.5f;
    protected float run_speed = 6f;

    //Get the Player movement
    private GameObject player;
    private Player_Movement_Script_New playerMovement;

    //Animation variables
    protected const string WALK_ANIM = "isWalking";
    protected const string RUN_ANIM = "isRunning";
    protected const string SPLITTED_ANIM = "isPitted";


    //Singleton
    private static Base_Behaviour base_instance =null;
    
    public static Base_Behaviour Get_Instance()
    {
        if(base_instance == null)
        {
            base_instance = new Base_Behaviour();
        }
        return base_instance;
    }

    protected Player_Movement_Script_New GetPlayerMovement()
    {
        if (playerMovement == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerMovement = (Player_Movement_Script_New)player.GetComponent(typeof(Player_Movement_Script_New));
        }
        return playerMovement;
    }

    public void Getspitted()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        player.GetComponent<Animator>().SetBool(SPLITTED_ANIM, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


}
