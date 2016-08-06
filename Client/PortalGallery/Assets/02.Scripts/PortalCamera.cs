using UnityEngine;
using System.Collections;

public class PortalCamera : MonoBehaviour {

	private Transform portalCamTr;
	public Transform portal;

	public GetPosition mainPortal;

	private Camera portalCamCam;

	public float xx;
	public float yy;
	public float zz;  // always '>=0'

	public float absoluteXx;
	public float absoluteYy;
	//public float absoluteZz;

	public float max;

	private float r = 3.6f;

	public float portalCamFov;

	public Material portalMat;
	public RenderTexture portalTexture2;

	// Use this for initialization
	void Start () {
		portalCamTr = GetComponent<Transform> ();
		portalCamCam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {

		xx = mainPortal.xx;
		yy = mainPortal.yy;
		zz = mainPortal.zz;  // always '>=0'

		portalCamTr.position = portal.position - new Vector3 (xx, yy, zz);

		absoluteXx = xx;
		if (xx < 0)
			absoluteXx = -xx;
		absoluteYy = yy;
		if (yy < 0)
			absoluteYy = -yy;
//		absoluteZz = zz;
//		if (zz < 0)
//			absoluteZz = -zz;

		max = Mathf.Max (absoluteXx, absoluteYy);


		portalCamCam.fieldOfView = portalCamFov;

		portalCamFov = Mathf.Atan2((max + r),zz) * 180.0f/3.1415926f * 2.0f;

		portalMat.mainTextureOffset = new Vector2 ((max + xx) / (2.0f * (max + r)), (max + yy) / (2.0f * (max + r)));
		portalMat.mainTextureScale = new Vector2 (r / (max + r), r / (max + r));


//		if (zz <= 0.5f) {
//			portalCamCam.targetTexture = portalTexture2;
//			portalMat.mainTexture = portalTexture2;
//		}

		//OnTriggerEnter,Exit






//		if (zz <= 5.0f) {
//			portalTexture.height = 4096;
//			//portalMat.mainTexture.
//			portalTexture.width = 4096;
//		}
//		else if (zz <= 10.0f){
//			portalTexture.height = 2048;
//			portalTexture.width = 2048;
//		}
//		else if (zz <= 50.0f){
//			portalTexture.height = 1024;
//			portalTexture.width = 1024;
//		}
//		else if (zz <= 200.0f){
//			portalTexture.height = 512;
//			portalTexture.width = 512;
//		}
//		else{
//			portalTexture.height = 256;
//			portalTexture.width = 256;
//		}
//
		//UnityEngine.RenderTexture:set_height(Int32)

	}
}
