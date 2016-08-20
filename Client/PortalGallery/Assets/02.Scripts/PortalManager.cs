using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PortalManager : MonoBehaviour
{
    private List<PortalGroup> m_portalGroupList = new List<PortalGroup>();
    private int m_portalGroupIndex = 0;
    private PortalGroup m_selectPortalGroup = null;

    // Use this for initialization
    void Start ()
    {
        PortalGroup[] portalGroups = FindObjectsOfType<PortalGroup>();
        foreach (var portalGroup in portalGroups)
        {
            m_portalGroupList.Add(portalGroup);
        }

        if (m_portalGroupList.Count > m_portalGroupIndex && m_portalGroupIndex >= 0)
        {
            m_selectPortalGroup = m_portalGroupList[m_portalGroupIndex];
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void LookAt(GameObject target)
    {
        Debug.Log("PortalManager.LookAt");
        if (m_selectPortalGroup != null)
        {
            m_selectPortalGroup.LookAt(target);
        }
    }

    public void MoveForward(float speed)
    {
        Debug.Log("PortalManager.MoveForward");
        if (m_selectPortalGroup != null)
        {
            m_selectPortalGroup.MoveForward(speed);
        }
    }

    public void MoveBackward(float speed)
    {
        Debug.Log("PortalManager.MoveForward");
        if (m_selectPortalGroup != null)
        {
            m_selectPortalGroup.MoveBackward(speed);
        }
    }

    public void MoveLeft(float speed)
    {
        Debug.Log("PortalManager.MoveLeft");
        if (m_selectPortalGroup != null)
        {
            m_selectPortalGroup.MoveLeft(speed);
        }
    }

    public void MoveRight(float speed)
    {
        Debug.Log("PortalManager.MoveRight");
        if (m_selectPortalGroup != null)
        {
            m_selectPortalGroup.MoveRight(speed);
        }
    }

    public void RotateX(float speed)
    {
        Debug.Log("PortalManager.RotateX");
        if (m_selectPortalGroup != null)
        {
            m_selectPortalGroup.RotateX(speed);
        }
    }

    public void RotateY(float speed)
    {
        Debug.Log("PortalManager.RotateY");
        if (m_selectPortalGroup != null)
        {
            m_selectPortalGroup.RotateY(speed);
        }
    }

    public void RotateZ(float speed)
    {
        Debug.Log("PortalManager.RotateZ");
        if (m_selectPortalGroup != null)
        {
            m_selectPortalGroup.RotateZ(speed);
        }
    }

    public void Stop()
    {
        Debug.Log("PortalManager.Stop");
        if (m_selectPortalGroup != null)
        {
            m_selectPortalGroup.Stop();
        }
    }

    public void Pick(GameObject viewer)
    {
        float minDist = float.MaxValue;
        foreach (var portalGroup in m_portalGroupList)
        {
            float dist = (viewer.transform.position - portalGroup.transform.position).sqrMagnitude;
            if (minDist > dist)
            {
                m_selectPortalGroup = portalGroup;
                minDist = dist;
            }
        }

        if (m_selectPortalGroup != null)
        {
            m_selectPortalGroup.Pick(viewer);
        }
    }

    public Portal GetSelectPortal()
    {
        return m_selectPortalGroup.SelectPortal;
    }
}
