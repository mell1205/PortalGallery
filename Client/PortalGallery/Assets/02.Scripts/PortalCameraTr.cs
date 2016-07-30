using UnityEngine;
using System.Collections;

public class PortalCameraTr : MonoBehaviour {

	private Transform portalCamTr;
	public Transform portal;
	private RaycastHit hit; 

	private float h;
	private float v;
	private float u;

	public float moveSpeed = 10.0f;

	public Vector3 z;
	public Vector3 xy;

	public float xx;
	public float yy;
	public float zz;

	public float absoluteXx;
	public float absoluteYy;
	public float absoluteZz;

	public float max;

	//private portalCamFov;


	// Use this for initialization
	void Start () {
		portalCamTr = GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		v = Input.GetAxis ("Vertical"); 
		h = Input.GetAxis ("Horizontal"); 
		u = Input.GetAxis ("Up");

		Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h) + (Vector3.up * u); 
		portalCamTr.Translate (moveDir.normalized *moveSpeed*Time.deltaTime); 

		Debug.DrawRay (portalCamTr.position, portalCamTr.forward * 1000.0f, Color.green);

		if (Physics.Raycast (portalCamTr.position, portalCamTr.forward, out hit, 1000.0f, 1 << LayerMask.NameToLayer ("PORTAL"))) 
		{
			z = hit.point - portalCamTr.position;
			xy = portal.position - hit.point;

			xx = xy.x;
			yy = xy.y;
			zz = z.z;

			absoluteXx = xx;
			if (xx < 0)
				absoluteXx = -xx;
			absoluteYy = yy;
			if (yy < 0)
				absoluteYy = -yy;
			absoluteZz = zz;
			if (zz < 0)
				absoluteZz = -zz;

			max = Mathf.Max (absoluteXx, absoluteYy);


		}





	}
}
