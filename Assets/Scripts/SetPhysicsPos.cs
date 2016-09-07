using UnityEngine;
using System.Collections;

public class SetPhysicsPos : MonoBehaviour {

    private Rigidbody r;
    public SteamVR_TrackedObject controller;

	// Use this for initialization
	void Start () {
        r = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        r.MovePosition(controller.transform.position);
        r.MoveRotation(controller.transform.rotation);
	}
}
