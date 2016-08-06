using UnityEngine;
using System.Collections;

public class EnterPortal : MonoBehaviour {

	public Transform portalCamTr;
		
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "MainCamera") {
			other.transform.position = portalCamTr.position;
		}
	}
}
