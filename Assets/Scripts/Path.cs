using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    [SerializeField] Color pathColor;
    private List<Transform> nodes = new List<Transform>();
    
    private void OnDrawGizmos()
    {
        Gizmos.color = pathColor;
        Transform[] pathTransforms = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for(int i = 0; i < pathTransforms.Length; i++)
        {
            if(pathTransforms[i] != transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }

        for(int i =  0;  i < nodes.Count; i++)
        {
            Vector3 currentNode = nodes[i].position;
            Vector3 previousNode = Vector3.zero;

            if(i > 0)
            {
                previousNode = nodes[i - 1].position;
            }else if (i==0 && nodes.Count > 1)
            {
                previousNode = nodes[nodes.Count - 1].position;
            }

            Gizmos.DrawLine(previousNode, currentNode);
            Gizmos.DrawSphere(currentNode, 0.3f);
            
        }
    }

    private void Awake()
    {
        Transform[] pathTransforms = GetComponentsInChildren<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    public Transform[] Get_Nodes()
    {
        Transform[] wayPoints = new Transform[nodes.Count];

        for (int i = 0; i < nodes.Count; i++)
        {
            wayPoints[i] = nodes[i];
        }
        return wayPoints;
    }
}
