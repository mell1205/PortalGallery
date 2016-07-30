using UnityEngine;
using System.Collections;

public class MainCameraTr : MonoBehaviour {

//	private float prevX;
//	private float prevY;
//	private float prevZ;
//
//	private float deltaX;
//	private float deltaY;
//	private float deltaZ;

	private Transform cameraTr;

	private float h;
	private float v;
	private float u;

	public float moveSpeed = 10.0f;

	// Use this for initialization
	void Start () {
		cameraTr = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		v = Input.GetAxis ("Vertical"); 
		h = Input.GetAxis ("Horizontal"); 
		u = Input.GetAxis ("Up");


		Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h) + (Vector3.up * u); 
		cameraTr.Translate (moveDir.normalized *moveSpeed*Time.deltaTime); 
	
	}
}
