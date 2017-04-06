using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarEngine : MonoBehaviour {

    public Transform path;
    public float maxSteerAngle = 40f;
    private List<Transform> nodes;
    private int currentNode = 0;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;

	// Use this for initialization
	void Start () {
        Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        foreach (Transform t in pathTransform)
        {
            if (t != path.transform)
                nodes.Add(t);
        }
    }

    void FixedUpdate() {
        ApplySteer();
    }
    void ApplySteer() {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
