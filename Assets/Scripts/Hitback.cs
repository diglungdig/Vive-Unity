using UnityEngine;
using System.Collections;

public class Hitback : MonoBehaviour {

    public Transform head;
    void OnCollisionEnter()
    {
        Rigidbody r = HoloMotionManager.instance.CurrentOne.GetComponent<Rigidbody>();
        r.angularVelocity = Vector3.zero;
        Vector3 dir = (head.position - r.transform.position).normalized;
        r.velocity = dir * Random.Range(18f, 30f);
        r.angularVelocity = dir * Random.Range(10f, 20f);
    }

}
