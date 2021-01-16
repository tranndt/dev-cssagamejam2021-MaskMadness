using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Mask_Attributes : MonoBehaviour
{
    private System.Random rnd = new System.Random();
    [SerializeField] float protect_value;

    public float Get_Value()
    {   
        return protect_value;
    }

    // Start is called before the first frame update
    void Start()
    {   
 
    }

    private void Awake()
    {
        protect_value = rnd.Next(15, 60);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 40 * Time.deltaTime);
    }

    public void Delete()
    {
        GameObject.Destroy(gameObject);
    }
}
