using UnityEngine;
using System.Collections;

public class GetPosition1 : MonoBehaviour {

	public Transform mainCamTr;

	public LayerManager layerMgr;

	private Transform portalTr;

	public RaycastHit hitZ; 
	public RaycastHit hitX;
	public RaycastHit hitY;

	public Vector3 z;
	public Vector3 x;
	public Vector3 y;


	public float xx;
	public float yy;
	public float zz; // zz is always 0,+. not -

	private int layerZ;
	private int layerX;
	private int layerY;


	// Use this for initialization
	void Start () {
		portalTr = GetComponent<Transform> ();
		layerMgr = GameObject.Find ("LayerManager").GetComponent<LayerManager> ();

		layerZ = gameObject.layer;

        layerX = portalTr.GetChild(1).gameObject.layer;

        layerY = portalTr.GetChild (0).gameObject.layer;


    }
	
	// Update is called once per frame
	void Update () 
	{

		if (Physics.Raycast (mainCamTr.position, portalTr.forward, out hitZ, 1000.0f, 1 << layerZ)) 
		{
			Debug.DrawRay (mainCamTr.position, portalTr.forward * 1000.0f, Color.blue);
			z = hitZ.point - mainCamTr.position;
			zz = z.magnitude;

			GetXandY ();

			// when passed, make portal rotate!!!!
		
		} 
		else if (Physics.Raycast (mainCamTr.position, -portalTr.forward, 1000.0f, 1 << layerZ)) 
		{
			portalTr.Rotate (portalTr.up, 180.0f);
		}

	}

	void GetXandY()
	{
		
		if (Physics.Raycast (hitZ.point, portalTr.right, out hitX, 1000.0f, 1 << layerX)) 
		{
			Debug.DrawRay (hitZ.point, portalTr.right * 1000.0f, Color.red);
			x = hitX.point - hitZ.point;
			xx = x.magnitude;
		}
		else if (Physics.Raycast (hitZ.point, -portalTr.right, out hitX, 1000.0f, 1 << layerX))
		{
			Debug.DrawRay (hitZ.point, -portalTr.right * 1000.0f, Color.red);
			x = hitX.point - hitZ.point;
			xx = -x.magnitude;
		}



		if (Physics.Raycast (hitZ.point, portalTr.up, out hitY, 1000.0f, 1 << layerY)) 
		{
			Debug.DrawRay (hitZ.point, portalTr.up * 1000.0f, Color.green);
			y = hitY.point - hitZ.point;
			yy = y.magnitude;
		}
		else if (Physics.Raycast (hitZ.point, -portalTr.up, out hitY, 1000.0f, 1 << layerY))
		{
			Debug.DrawRay (hitZ.point, -portalTr.up * 1000.0f, Color.green);
			y = hitY.point - hitZ.point;
			yy = -y.magnitude;
		}
			
	}

//	void OnCollisionEnter(Collision coll)
//	{
//		 coll.contacts[0].
//	}
}