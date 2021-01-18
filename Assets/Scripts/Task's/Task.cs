using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    private string description;
    private bool done;
    // Start is called before the first frame update

    public Task(string description) {
        this.description = description;
        this.done = false;
    }
    public void MarkAsDone() {
        this.done = true;
    }

    bool IsDone() {
        return this.done;
    }
}
