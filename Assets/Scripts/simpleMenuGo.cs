using UnityEngine;
using System.Collections;

public class simpleMenuGo : MonoBehaviour {
    public SteamVR_LaserPointer lp;

    public GameObject[] SetDeActiveObjectList;
    public GameObject[] SetActiveObjectList;

    public SteamVR_TrackedObject trackedObj;
    private GameObject currentObject;
    private bool started = false;
    // Use this for initialization
    void Start () {
	    if(GetComponent<SteamVR_LaserPointer>() != null)
        {
            GetComponent<SteamVR_LaserPointer>().PointerIn += new PointerEventHandler(inIt);
        }
	}
   private void inIt(object sender, PointerEventArgs args)
    {
        currentObject = args.target.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger) && currentObject.name == "StartBall" && !started)
        {

            if (SetDeActiveObjectList.Length != 0)
            {
                for (int i = 0; i < SetDeActiveObjectList.Length; i++)
                {
                    SetDeActiveObjectList[i].SetActive(false);
                }
            }
            lp.active = false;
            //hard coding
            transform.GetChild(0).gameObject.SetActive(false);


            transform.GetChild(1).gameObject.SetActive(false);

            if (SetActiveObjectList.Length != 0)
            {
                for (int i = 0; i < SetActiveObjectList.Length; i++)
                {
                    SetActiveObjectList[i].SetActive(true);
                }
            }
            started = true;
        }
    }
}
