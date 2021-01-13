using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation_Fix : MonoBehaviour
{
    //Declare the Animator
    private Animator animator;

    //Animator condition variables
    private const string WALK_ANIM = "isWalking";
    private const string RUN_ANIM  = "isRunning";
    private const string LEFT_WALK_ANIM = "isWalkingLeft";
    private const string RIGHT_WALK_ANIM = "isWalkingRight";
    //private string[] animation_list;

    private List<string> animation_list;

    // Start is called before the first frame update
    void Start()
    {
        animation_list = new List<string>();

        animation_list.Add(WALK_ANIM);
        animation_list.Add(RUN_ANIM);
        animation_list.Add(LEFT_WALK_ANIM);
        animation_list.Add(RIGHT_WALK_ANIM);

        animator = gameObject.GetComponent<Animator>();
    }

    public void Play_Idle_Anim()
    {
        foreach(string anim in animation_list)
        {
            animator.SetBool(anim, false);
            
        }
    }

    public void Play_Walk_Anim()
    {
        animator.SetBool(WALK_ANIM, true);
    }

    public void Play_Walk_To_Idle_Anim()
    {
        animator.SetBool(WALK_ANIM, false);
    }

    public void Play_Run_Anim()
    {
        animator.SetBool(WALK_ANIM, true);
        animator.SetBool(RUN_ANIM, true);
    }

    public void Play_Run_To_Idle_Anim()
    {
        animator.SetBool(WALK_ANIM, false);
        animator.SetBool(RUN_ANIM, false);
    }

    public void Play_Left_Walk_Anim()
    {
        animator.SetBool(RIGHT_WALK_ANIM, false);
        animator.SetBool(LEFT_WALK_ANIM, true);
    }

    public void Play_Right_Walk_Anim()
    {
        animator.SetBool(LEFT_WALK_ANIM, false);
        animator.SetBool(RIGHT_WALK_ANIM, true);
    }
}
