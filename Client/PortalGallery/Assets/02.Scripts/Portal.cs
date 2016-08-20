using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    public enum Mode
    {
        MoveForward,
        MoveBackward,
        MoveLeft,
        MoveRight,
        MoveUp,
        MoveDown,
        Rotate,
        RotateX,
        RotateY,
        RotateZ,
        None,
    }

    public float m_speed = 0;
    public Mode m_mode = Mode.None;

    private Vector3 m_rotation = Vector3.zero;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch(m_mode)
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

    void OnDestroy()
    {
        var portalGroup = GetComponentInParent<PortalGroup>();
        if (portalGroup != null)
            portalGroup.Remove(this);
    }

    public void LookAt(  GameObject target)
    {
        // angle
        Vector3 dir = (target.transform.position - transform.position).normalized;
        Debug.Log(dir);
        Debug.Log(transform.forward);
        var angle = Vector3.Angle(-transform.forward, dir);

        // target local position
        var targetLocalPosition = transform.InverseTransformPoint(target.transform.position);
        if (targetLocalPosition.x > 0)
        {
            // right
            Debug.Log("portal rotate right");
            angle = -angle;
        }
        else
        {
            // left
            Debug.Log("portal rotate left");
        }

        // dir
       
        Debug.Log(angle);
        m_rotation += new Vector3(0, angle, 0);

        // rotate
        iTween.RotateTo(gameObject, iTween.Hash("rotation", m_rotation, "time", 1));
        //iTween.RotateBy(gameObject, iTween.Hash("amount", new Vector3(0, angle, 0), "time", 1));
    }
    
    public void MoveForward(float speed)
    {
        m_mode = Mode.MoveForward;
        m_speed = speed;
    }

    public void MoveBackward(float speed)
    {
        m_mode = Mode.MoveBackward;
        m_speed = speed;
    }

    public void MoveLeft(float speed)
    {
        m_mode = Mode.MoveLeft;
        m_speed = speed;
    }

    public void MoveRight(float speed)
    {
        m_mode = Mode.MoveRight;
        m_speed = speed;
    }

    public void RotateX(float speed)
    {
        m_mode = Mode.RotateX;
        m_speed = speed;
    }

    public void RotateY(float speed)
    {
        m_mode = Mode.RotateY;
        m_speed = speed;
    }

    public void RotateZ(float speed)
    {
        m_mode = Mode.RotateZ;
        m_speed = speed;
    }

    public void Stop()
    {
        m_mode = Mode.None;
        m_speed = 0;
    }
}
