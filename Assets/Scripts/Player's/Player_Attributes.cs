using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attributes : MonoBehaviour
{
    private string DEAD_ANIM = "isDead";
    private float immute;
    private float mask;
    MaskBarScript maskBar;
    ISBarScript immuteBar;
    private bool isDead;

    GameObject finder;

    private Animator animator;

    public float Get_Immute()
    {
        return immute;
    }

    public float Get_Mask()
    {
        return mask;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        animator = GetComponent<Animator>();

        finder = GameObject.Find("MASK");
        maskBar = (MaskBarScript)finder.GetComponent(typeof(MaskBarScript));


        finder = GameObject.Find("ImmuneSystemBar");
        immuteBar = (ISBarScript)finder.GetComponent(typeof(ISBarScript));

        immuteBar.SetMaxImSys(100f);
        maskBar.SetMaxMask(100f);

        immute = 100f;
        mask = 20f;
        maskBar.SetMask(mask);
        immuteBar.SetIm(immute);

        InvokeRepeating("Endurance", 1f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            CheckDead();
            Play_Sound();
        }
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        //if (collider.gameObject.layer == 15)
        //{
        //    Debug.Log("Mask picked up");
        //    FindObjectOfType<AudioManager>().Play("pickup");
        //    GameObject mask_object = collider.gameObject;
        //    if (mask_object != null)
        //    {
        //        var maskObj = mask_object.GetComponent<Mask_Attributes>();
        //        mask += maskObj.Get_Value();
        //        maskBar.SetMask(mask);
        //    }
        //    Destroy(collider.gameObject);
        //}
    }

    public void Attacked()
    {
        if (mask >0)
        {
            mask -= 7f;
            maskBar.SetMask(mask);

            //play laugh sound
        }
        else
        {
            immute -= 8f;
            immuteBar.SetIm(immute);
            //play hurt sound
        }

        if(mask == 0 && immute >=90f)
        {
            if (!FindObjectOfType<AudioManager>().isPlaying("ohshit"))
            {
                FindObjectOfType<AudioManager>().Play("ohshit");
            }
        }
    }

    private void Play_Sound()
    {
        if (mask >0)
        {

        }
        else
        {
            if (!FindObjectOfType<AudioManager>().isPlaying("cough"))
            {
                FindObjectOfType<AudioManager>().Play("cough");
            }
        }
    }

    private void Endurance()
    {
        if (mask >= 0)
        {
            mask -= 2f;
        }
        else
        {
            immute -= 4f;
        }
        maskBar.SetMask(mask);
        immuteBar.SetIm(immute);
    }

    private void CheckDead()
    {
        if (immute <= 0)
        {
            animator.SetBool(DEAD_ANIM, true);
            isDead = true;
        }
    }
}
