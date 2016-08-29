using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/3dsMax Camera Style")]
public class CameraMaxStyle : MonoBehaviour {





    public class maxCamera_combined : MonoBehaviour
    {
        //Meine
        private bool tswitch = true;

        // Orbit
        public Transform target;

        // maxCamera
        public Transform temp;
        public Vector3 tempOffset;
        public float distance = 5.0f;
        public float maxDistance = 20;
        public float minDistance = .6f;
        public float xSpeed = 200.0f;
        public float ySpeed = 200.0f;
        public int yMinLimit = -80;
        public int yMaxLimit = 80;
        public int zoomRate = 40;
        public float panSpeed = 0.3f;
        public float zoomDampening = 5.0f;
        public float xDeg = 0.0f;
        public float yDeg = 0.0f;
        public float currentDistance;
        public float desiredDistance;
        private Quaternion currentRotation;
        private Quaternion desiredRotation;
        private Quaternion rotation;
        private Vector3 position;


 


    void Start() { Init(); }


    void OnEnable() { Init(); }

    public void Init()


    {


      //If there is no temp, create a temporary temp at 'distance' from the cameras current viewpoint


        if (!temp)


        {


            GameObject go = new GameObject("Cam temp");


            go.transform.position = transform.position + (transform.forward* distance);


            temp = go.transform;


        }


 


        distance = Vector3.Distance(transform.position, temp.position);


        currentDistance = distance;


       desiredDistance = distance;


               


        //be sure to grab the current rotations as starting points.


        position = transform.position;


        rotation = transform.rotation;


        currentRotation = transform.rotation;


        desiredRotation = transform.rotation;

      


        xDeg = Vector3.Angle(Vector3.right, transform.right );


        yDeg = Vector3.Angle(Vector3.up, transform.up );


    }


    /*


     * Camera logic on LateUpdate to only update after all character movement logic has been handled.


     */


    void LateUpdate()

    {


        if (Input.GetKeyDown("b")) { //LOCAL OFF


           tswitch = false;
           //Change camera position to target, BUT HOW????


           



           

        
           }


        if (Input.GetKeyDown("v")) {


            tswitch = true;


           


           // Sets temp-position in front of cam


            temp.transform.position = transform.position + (transform.forward* desiredDistance);   


        }


       if (tswitch) {


       // If Control and Alt and Middle button? ZOOM!


       if (Input.GetMouseButton(2) || Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.LeftControl))
       {

           desiredDistance -= Input.GetAxis("Mouse Y") * Time.deltaTime * zoomRate*0.125f * Mathf.Abs(desiredDistance);


        }


        // If middle mouse and left alt are selected? ORBIT


        else if (Input.GetMouseButton(2) || Input.GetKey(KeyCode.LeftAlt))
        {


            xDeg += Input.GetAxis("Mouse X") * xSpeed * 0.02f;


            yDeg -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
 


           ////////OrbitAngle




            //Clamp the vertical axis for the orbit


            yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);


           // set camera rotation


            desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);


            currentRotation = transform.rotation;

          

            rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime* zoomDampening);


           transform.rotation = rotation;

        }


        // otherwise if middle mouse is selected, we pan by way of transforming the temp in screenspace


        else if (Input.GetMouseButton(2))


        {


           //grab the rotation of the camera so we can move in a psuedo local XY space


            temp.rotation = transform.rotation;


            temp.Translate(Vector3.right* -Input.GetAxis("Mouse X") * panSpeed); // these move temp


            temp.Translate(transform.up* -Input.GetAxis("Mouse Y") * panSpeed, Space.World);


        }





       ////////Orbit Position





        // affect the desired Zoom distance if we roll the scrollwheel


       desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate* Mathf.Abs(desiredDistance);


        //clamp the zoom min/max


       desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);


       // For smoothing of the zoom, lerp distance


       currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime* zoomDampening);





        // calculate position based on the new currentDistance


       position = temp.position - (rotation* Vector3.forward * currentDistance + tempOffset);


       transform.position = position;


   }


 


    if (!tswitch) {



        xDeg += Input.GetAxis("Mouse X") * xSpeed * 0.02f;


        yDeg -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;


      yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);



      desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);

    


          

        //position = rotation * Vector3(0.0f, 0.0f, -distance) + target.position;  


        currentRotation = transform.rotation; // if this is off, cam wiggles


        rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime* zoomDampening);


 


        // affect the desired Zoom distance if we roll the scrollwheel


        desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate* Mathf.Abs(desiredDistance);


        //clamp the zoom min/max

        desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);


       // For smoothing of the zoom, lerp distance


       currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime* zoomDampening);


      


       //Important for Zoom!!!


       position = target.position - (rotation* Vector3.forward * currentDistance);


        //PROBLEM at switch from V to B

     

       transform.rotation = rotation;


       transform.position = position;




    }   


   





}


 


    private static float ClampAngle(float angle, float min, float max)


    {


        if (angle< -360)


            angle += 360;


        if (angle > 360)


            angle -= 360;


        return Mathf.Clamp(angle, min, max);


    }


}




}
