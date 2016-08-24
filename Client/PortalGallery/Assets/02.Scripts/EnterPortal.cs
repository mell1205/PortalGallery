using UnityEngine;
using System.Collections;

public class EnterPortal : MonoBehaviour {



    public Transform portalCamTr;
    public Transform portal;


    void OnTriggerEnter(Collider other)
	{
		if (other.tag == "MainCamera") {

            portalCamTr.position = portal.position;

            other.transform.position = portalCamTr.position;
		}
	}
}
