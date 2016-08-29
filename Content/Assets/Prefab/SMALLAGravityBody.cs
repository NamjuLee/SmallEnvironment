using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SMALLAGravityBody : MonoBehaviour {

    SMALLAGravityAttractor planet;
    Rigidbody newrigidbody;

    void Awake() {
        planet = GameObject.FindGameObjectWithTag("SMALLAplanet").GetComponent<SMALLAGravityAttractor>();
        newrigidbody = GetComponent<Rigidbody>();

        // Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
        newrigidbody.useGravity = false;
        newrigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate() {
        // Allow this body to be influenced by planet's gravity
        planet.Attract(newrigidbody);
    }



    void OnMouseDrag() {

        ObjectFindWithRay();
        //Destroy(this);

    }


    int tt = 0;
    void OnMouseDown()
    {
        
        
        tt++;

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(tt);
            //Destroy(this);
            tt++;

        }
        else
        {

           ObjectFindWithRay();
        }
        //Destroy(this);
    }

    Random rnd = new Random();

    //GameObject tree;
    void ObjectFindWithRay()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 500))
        {

            GameObject obj = Instantiate(this, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
            obj.transform.localScale = new Vector3(0.9f , 0.9f , 0.9f );
            obj.transform.up = hit.normal;
            //Debug.Log(hit.transform.position);
            this.transform.position = hit.transform.position;
        }
        


    }


}