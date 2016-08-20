using UnityEngine;
using System.Collections;


[RequireComponent(typeof(PortalManager))]
public class PortalGalleryApp : MonoBehaviour {

    public enum InputModes
    {
        Portal,
        User
    }

    public static InputModes        InputMode       { get; set; }

    public static MainCameraTr      MainCamera      { get; set; }
    public static PortalManager     PortalManager   { get; set; }
    
    public float moveSpeed = 1;
    public float rotateSpeed = 10;

    void Awake()
    {
        DontDestroyOnLoad(this);

        InitializeManager();
    }

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        UpdateInput();
	}

    private void InitializeManager()
    {
        MainCamera      = FindObjectOfType<MainCameraTr>();
        Debug.Log(MainCamera);

        // PortalManager
        PortalManager   = GetComponent<PortalManager>();
        Debug.Log(PortalManager);
    }

    private void UpdateInput()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            // Portal mode
            InputMode = InputModes.Portal;
            Debug.Log("InputMode Portal.");
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            // User mode
            InputMode = InputModes.User;
            Debug.Log("InputMode User.");
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            Debug.Log("Rotate test");
            if (InputMode == InputModes.Portal)
            {

            }
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            Debug.Log("Look at main camera.");
            PortalManager.LookAt(MainCamera.gameObject);
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            Debug.Log("Move forward!");
            PortalManager.MoveForward(moveSpeed);
        }

        if (Input.GetKeyUp(KeyCode.N))
        {
            Debug.Log("Move backward!");
            PortalManager.MoveBackward(moveSpeed);
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            Debug.Log("Move left!");
            PortalManager.MoveLeft(moveSpeed);
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            Debug.Log("Move right!");
            PortalManager.MoveRight(moveSpeed);
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            Debug.Log("Rotate x axis!");
            PortalManager.RotateX(rotateSpeed);
        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            Debug.Log("Rotate y axis!");
            PortalManager.RotateY(rotateSpeed);
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            Debug.Log("Rotate z axis!");
            PortalManager.RotateZ(rotateSpeed);
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            Debug.Log("Pick");
            PortalManager.Pick(MainCamera.gameObject);
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            Debug.Log("Enter");
            var portal = PortalManager.GetSelectPortal();
            if (portal != null)
            {
                MainCamera.Enter(portal.gameObject);
            }
        }

        if (Input.GetKeyUp(KeyCode.Y))
        {
            Debug.Log("User/Portal");
        }

        if (Input.GetKeyUp(KeyCode.U))
        {
            Debug.Log("Portal/1Unit");
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            Debug.Log("Stop");
            PortalManager.Stop();
        }

        if (Input.GetKeyUp(KeyCode.O))
        {

        }

        if (Input.GetKeyUp(KeyCode.P))
        {

        }
    }
}
