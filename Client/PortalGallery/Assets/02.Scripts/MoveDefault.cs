using UnityEngine;
using System.Collections;

public class MoveDefault : MonoBehaviour {

	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time >= 3.0f)
			transform.Translate (-Vector3.forward * 0.1f);	
	
	}
}
