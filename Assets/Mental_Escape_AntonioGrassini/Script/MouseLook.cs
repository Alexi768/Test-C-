using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{


    public Transform body;
    public Transform head;
    public Quaternion x_rotation = Quaternion.identity;
    public Quaternion y_rotation = Quaternion.identity;
    public float rotation_speed;
    public float horizontal;
    public float vertical;
    public float min;
    public float max;
    public Quaternion temp;
    public Cube_Movement player;
    public bool can_look;
    // Use this for initialization
    void Start()
    {
        x_rotation = transform.localRotation;
        y_rotation = head.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (can_look)
        {
            horizontal = Input.GetAxis("Mouse X") * rotation_speed;
            vertical = Input.GetAxis("Mouse Y") * rotation_speed;

            x_rotation *= Quaternion.Euler(0f, horizontal, 0f);
            y_rotation *= Quaternion.Euler(-vertical, 0f, 0f);

            y_rotation = ClampRotationAroundXAxis(y_rotation, min, max);

            head.transform.localRotation = y_rotation;
            transform.localRotation = x_rotation;
        }
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q, float MinimumX, float MaximumX)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
