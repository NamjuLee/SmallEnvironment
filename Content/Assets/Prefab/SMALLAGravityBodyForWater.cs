using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class SMALLAGravityBodyForWater : MonoBehaviour {


    SMALLAGravityAttractor planet;
    Rigidbody newrigidbody;

    void Awake()
    {
        planet = GameObject.FindGameObjectWithTag("SMALLAplanet").GetComponent<SMALLAGravityAttractor>();
        newrigidbody = GetComponent<Rigidbody>();

        // Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
        newrigidbody.useGravity = false;
        newrigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        // Allow this body to be influenced by planet's gravity
        planet.Attract(newrigidbody);
    }


    private Vector3 screenPoint;
    private Vector3 offset;
    void OnMouseDrag()
    {

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }


    int tt = 0;
    void OnMouseDown()
    {

        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    Random rnd = new Random();






}
