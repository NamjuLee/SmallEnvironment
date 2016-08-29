using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {


    public Transform target;
    public float distance;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;
    public float wheelScale = 10f;

    public float yMinLimit = -80f;
    public float yMaxLimit = 40f;

    public float distanceMin = .5f;
    public float distanceMax = 10f;


    float x = 0.0f;
    float y = 0.0f;



    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
        // Make the rigid body not change rotation

    }


    void LateUpdate()
    {
        //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));

        if (target)
        {

            if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
            {
                distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * wheelScale, distanceMin, distanceMax);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
            {
                distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * wheelScale, distanceMin, distanceMax);
            }
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;

            if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
            {
                //Debug.Log("Pressed left click.");
                x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                y = ClampAngle(y, yMinLimit, yMaxLimit);

                distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * wheelScale, distanceMin, distanceMax);

                negDistance = new Vector3(0.0f, 0.0f, -distance);
                position = rotation * negDistance + target.position;

                transform.rotation = rotation;
                transform.position = position;
            }
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

}
