using UnityEngine;
using System.Collections;

public class MagnusEffect : MonoBehaviour {
    public float MagnusConstant = 0.07f;

    private Rigidbody r;

	// Use this for initialization
	void Start () {
        r = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 force = MagnusConstant * Vector3.Cross(r.velocity, r.angularVelocity);
        r.AddRelativeForce(force);
	}
}
