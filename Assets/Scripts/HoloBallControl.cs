using UnityEngine;
using System.Collections;

public class HoloBallControl : MonoBehaviour {

    private Rigidbody r;

    private bool hit = false;
    private AudioSource a;
	// Use this for initialization
	void Start () {
        r = GetComponent<Rigidbody>();
        a = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (hit && r.velocity.magnitude < 2.5f)
            Destroy(this.gameObject);
	}

    void OnCollisionEnter(Collision col)
    {
        hit = true;
        if(col.collider.gameObject.name == "thebackWall")
        {
            Destroy(this.gameObject);
        }
        else if(col.collider.gameObject.name == "Leftbaseball_bat" || col.collider.gameObject.name == "Rightbaseball_bat")
        {
            a.Play();
        }
    }
}
