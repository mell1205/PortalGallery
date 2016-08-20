using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalGroup : MonoBehaviour
{
    public enum Mode
    {
        MoveForward,
        MoveBackward,
        MoveLeft,
        MoveRight,
        MoveUp,
        MoveDown,
        RotateX,
        RotateY,
        RotateZ,
        None,
    }

    public Vector3 m_origin = Vector3.zero;
    public Vector3 m_dir = Vector3.zero;
    public float m_gap = 0;

    public float m_speed = 0;
    public Mode m_mode = Mode.None;

    public Portal SelectPortal { get { return m_selectPortal;  } }

    private List<Portal> m_portalList = new List<Portal>();
    private Portal m_selectPortal = null;


	// Use this for initialization
	void Start () {
        var portals = GetComponentsInChildren<Portal>(true);

        foreach (var portal in portals)
        {
            Debug.Log(portal.transform.position);
            m_portalList.Add(portal);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (m_mode)
        {
            case Mode.MoveForward:
                transform.Translate(-transform.forward * m_speed * Time.deltaTime);
                break;
            case Mode.MoveBackward:
                transform.Translate(transform.forward * m_speed * Time.deltaTime);
                break;
            case Mode.MoveLeft:
                transform.Translate(-transform.right * m_speed * Time.deltaTime);
                break;
            case Mode.MoveRight:
                transform.Translate(transform.right * m_speed * Time.deltaTime);
                break;
            case Mode.MoveUp:
                transform.Translate(transform.up * m_speed * Time.deltaTime);
                break;
            case Mode.MoveDown:
                transform.Translate(-transform.up * m_speed * Time.deltaTime);
                break;
            case Mode.RotateX:
                transform.Rotate(m_speed * Time.deltaTime, 0, 0);
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + m_speed * Time.deltaTime, transform.eulerAngles.z);
                break;
            case Mode.RotateY:
                transform.Rotate(0, m_speed * Time.deltaTime, 0);
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + m_speed * Time.deltaTime, transform.eulerAngles.z);
                break;
            case Mode.RotateZ:
                transform.Rotate(0, 0, m_speed * Time.deltaTime);
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + m_speed * Time.deltaTime, transform.eulerAngles.z);
                break;
        }
    }

    public void Add(Portal portal)
    {
        m_portalList.Add(portal);
    }

    public void Remove(Portal portal)
    {
        m_portalList.Remove(portal);
    }

    public Portal Find(GameObject portalObj)
    {
        return m_portalList.Find(portal => portal.gameObject == portalObj);
    }

    public void LookAt(GameObject target)
    {
        Debug.Log("PortalManager.LookAt");
        if (m_selectPortal != null)
        {
            m_selectPortal.LookAt(target);
        }
        else
        {
            foreach (Portal portal in m_portalList)
            {
                portal.LookAt(target);
            }
        }
    }

    public void MoveForward(float speed)
    {
        Debug.Log("PortalManager.MoveForward");
        //foreach (Portal portal in m_portalList)
        //{
        //    portal.MoveForward(speed);
        //}
        if (m_selectPortal != null)
        {
            m_selectPortal.MoveForward(speed);
        }
        else
        {
            m_mode = Mode.MoveForward;
            m_speed = speed;
        }
    }

    public void MoveBackward(float speed)
    {
        Debug.Log("PortalManager.MoveBackward");
        //foreach (Portal portal in m_portalList)
        //{
        //    portal.MoveBackward(speed);
        //}
        if (m_selectPortal != null)
        {
            m_selectPortal.MoveBackward(speed);
        }
        else
        {
            m_mode = Mode.MoveBackward;
            m_speed = speed;
        }
    }

    public void MoveLeft(float speed)
    {
        Debug.Log("PortalManager.MoveLeft");
        //foreach (Portal portal in m_portalList)
        //{
        //    portal.MoveLeft(speed);
        //}
        if (m_selectPortal != null)
        {
            m_selectPortal.MoveLeft(speed);
        }
        else
        {
            m_mode = Mode.MoveLeft;
            m_speed = speed;
        }
    }

    public void MoveRight(float speed)
    {
        Debug.Log("PortalManager.MoveRight");
        //foreach (Portal portal in m_portalList)
        //{
        //    portal.MoveRight(speed);
        //}
        if (m_selectPortal != null)
        {
            m_selectPortal.MoveRight(speed);
        }
        else
        {
            m_mode = Mode.MoveRight;
            m_speed = speed;
        }
    }

    public void RotateX(float speed)
    {
        if (m_selectPortal != null)
        {
            m_selectPortal.RotateX(speed);
        }
        else
        {
            m_mode = Mode.RotateX;
            m_speed = speed;
        }
        //Quaternion.Euler(0, )
    }

    public void RotateY(float speed)
    {
        if (m_selectPortal != null)
        {
            m_selectPortal.RotateY(speed);
        }
        else
        {
            m_mode = Mode.RotateY;
            m_speed = speed;
        }
        //Quaternion.Euler(0, )
    }

    public void RotateZ(float speed)
    {
        if (m_selectPortal != null)
        {
            m_selectPortal.RotateZ(speed);
        }
        else
        {
            m_mode = Mode.RotateZ;
            m_speed = speed;
        }
        //Quaternion.Euler(0, )
    }

    public void Stop()
    {
        if (m_selectPortal != null)
        {
            m_selectPortal.Stop();
            m_selectPortal = null;
        }
        else
        {
            m_mode = Mode.None;
            m_speed = 0;
        }
    }

    public void Pick(GameObject viewer)
    {
        float minDist = float.MaxValue;
        foreach (var portal in m_portalList)
        {
            float dist = (viewer.transform.position - portal.transform.position).sqrMagnitude;
            if (minDist > dist)
            {
                m_selectPortal = portal;
                minDist = dist;
            }
        }
    }
}
