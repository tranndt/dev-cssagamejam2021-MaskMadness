using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    [SerializeField] Text healthValue;
    // Start is called before the first frame update
    void Start()
    {
        healthValue.text = "100%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
