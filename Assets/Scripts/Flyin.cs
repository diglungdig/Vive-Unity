using UnityEngine;
using System.Collections;

public class Flyin : MonoBehaviour {

    public Transform head;
    public SteamVR_TrackedObject leftHand;
    public SteamVR_TrackedObject rightHand;

    private bool isFlying = false;
	
	// Update is called once per frame
	void Update () {

        var Ldevice = SteamVR_Controller.Input((int)leftHand.index);
        var Rdevice = SteamVR_Controller.Input((int)rightHand.index);

        if (Ldevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) || Rdevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            isFlying = !isFlying;
        }

        if (isFlying)
        {
            Vector3 leftDir = leftHand.transform.position - head.position;
            Vector3 rightDir = rightHand.transform.position - head.position;

            Vector3 dir = leftDir + rightDir;

            transform.position += (dir * 0.1f);
        }
    }
}
