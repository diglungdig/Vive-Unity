using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    private bool isAttached = false;

    private bool isFired = false;

    void OnTriggerStay()
    {
        AttachArrow();
    }

    void OnTriggerEnter()
    {
        AttachArrow();
    }

    public void Fired()
    {
        isFired = true;
        GetComponent<Collider>().isTrigger = false;
    }
    void Update()
    {
        if (isFired && transform.GetComponent<Rigidbody>().velocity.magnitude > 4f)
        {
            transform.LookAt(transform.position+transform.GetComponent<Rigidbody>().velocity);
        }
    }


    private void AttachArrow()
    {
        var device = SteamVR_Controller.Input((int)ArrowManager.Instance.trackedObj.index);
        if (!isAttached && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            ArrowManager.Instance.AttachBowToArrow();
            isAttached = true;
        }
    }
}
