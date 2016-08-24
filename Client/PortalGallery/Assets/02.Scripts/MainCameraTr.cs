using UnityEngine;
using System.Collections;

public class MainCameraTr : MonoBehaviour
{
    public enum Mode
    {
        Input,
        Enter,
    }
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

	public float moveSpeed = 1.0f;
    private Mode m_mode = Mode.Input;
    private GameObject m_portalObj = null;

	// Use this for initialization
	void Start () {
		cameraTr = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

        if (m_mode == Mode.Input)
        {
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");
            u = Input.GetAxis("Up");


            Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h) + (Vector3.up * u);
            //Vector3 moveDir = Vector3.forward + Vector3.right + Vector3.up;
            cameraTr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);
            //cameraTr.Translate (Vector3.forward*moveSpeed*Time.deltaTime);
        }
        else if (m_mode == Mode.Enter)
        {

        }
    }

    public void Enter(GameObject portalObj)
    {
        m_portalObj = portalObj;
    }
}
