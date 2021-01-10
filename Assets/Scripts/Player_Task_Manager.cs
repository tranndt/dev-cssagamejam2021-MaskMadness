using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Task_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Toggle[] tasks;

    private string[] task_pool;



    void Start()
    {
        task_pool = new string[4];

        task_pool[0] = "pick up 4 masks";
        task_pool[1] = "buy some milk";
        task_pool[2] = "bring it home";
        task_pool[3] = "come home with full immute";

        for(int i = 0; i< task_pool.Length; i++)
        {
            //tasks[i].gameObject.GetComponent<TextMeshPro>().SetText (task_pool[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}
