﻿using UnityEngine;
using System.Collections;

public class ArrowManager : MonoBehaviour {

    public static ArrowManager Instance;
    public SteamVR_TrackedObject trackedObj;
    private GameObject currentArrow;
    public GameObject arrowPrefab;

    public GameObject stringStartPoint;
    public GameObject stringAttachPoint;
    public GameObject arrowStartPoint;


    private bool isAttached = false;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

	// Update is called once per frame
	void Update () {
        AttachArrow();
        PullString();
	}

    private void PullString()
    {
        if (isAttached)
        {
            float dist = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;
            stringAttachPoint.transform.localPosition = stringStartPoint.transform.localPosition + new Vector3(5*dist, 0f, 0f);

            var device = SteamVR_Controller.Input((int)trackedObj.index);
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Fire();
            }
         }
    }


    private void Fire()
    {
        float dist = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;
        currentArrow.transform.parent = null;
        currentArrow.GetComponent<Arrow>().Fired();
        Rigidbody r = currentArrow.GetComponent<Rigidbody>();
        r.velocity = currentArrow.transform.forward * 20f * dist;
        r.useGravity = true;

        stringAttachPoint.transform.position = stringStartPoint.transform.position;

        currentArrow = null;
        isAttached = false;
    }

    private void AttachArrow()
    {
        if (currentArrow == null)
        {
            currentArrow = Instantiate(arrowPrefab);
            currentArrow.transform.parent = trackedObj.transform;
            currentArrow.transform.localPosition = new Vector3(0f, 0f, 0.342f);
            currentArrow.transform.localRotation = Quaternion.identity;
        }
    }

    public void AttachBowToArrow()
    {
        currentArrow.transform.parent = stringAttachPoint.transform;
        currentArrow.transform.localPosition = arrowStartPoint.transform.localPosition;
        currentArrow.transform.rotation = arrowStartPoint.transform.rotation;

        isAttached = true;
    }
}
