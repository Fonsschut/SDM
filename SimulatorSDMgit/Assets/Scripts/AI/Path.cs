using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour
{
    public Color limecolor;
    private List<Transform> nodes = new List<Transform>();

    void OnDrawGizmosSelected()
    {
        Gizmos.color = limecolor;
        Transform[] pathTransform = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        foreach(Transform t in pathTransform)
        {
            if (t != transform)
                nodes.Add(t);
        }

        for(int i = 0; i < nodes.Count; i++)
        {
            Vector3 currentNode = nodes[i].position;
            Vector3 previousNode = Vector3.zero;
            if (i > 0)          
                previousNode = nodes[i - 1].position;      
            else if ( i == 0 && nodes.Count > 1)
                previousNode = nodes[nodes.Count - 1].position;

            Gizmos.DrawLine(previousNode,currentNode);
            Gizmos.DrawWireSphere(currentNode, 0.2f);
        }
    }


}
