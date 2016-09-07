using UnityEngine;
using System.Collections;

public class HoloMotionManager : MonoBehaviour {

    public GameObject[] Prefab;

    [HideInInspector]
    public GameObject CurrentOne;

    public static HoloMotionManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }

	// Update is called once per frame
	void Update () {
	    if(CurrentOne == null)
        {
            CurrentOne = (GameObject)Instantiate(Prefab[Random.Range(0,3)], transform.position, transform.rotation);
            CurrentOne.transform.FindChild("Character").gameObject.GetComponent<FacialExpressions>().enabled = false;
            CurrentOne.transform.FindChild("Character").gameObject.GetComponent<Animator>().enabled = false;
        }
	}
}
