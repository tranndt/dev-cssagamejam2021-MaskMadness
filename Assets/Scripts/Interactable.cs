using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] bool isInrange;
    [SerializeField] KeyCode interactKey;
    public UnityEvent interaction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInrange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interaction?.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInrange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInrange = false;
    }


}
