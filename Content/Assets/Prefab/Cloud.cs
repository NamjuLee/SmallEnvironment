using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cloud : MonoBehaviour {

    public GameObject water;
    public float rainRate = 1.5f;


    Scrollbar btRainRate;






        float t;
    float tt;
    void Awake()
    {

        btRainRate = GameObject.Find("BtnRain").GetComponent<Scrollbar>();
        btRainRate.value = 1f;
            //if(water == null) water = GameObject.FindGameObjectWithTag("water");
    }

    public void Start()
    {

    }


    float PlanetRotateSpeed = -25.0f;
    float OrbitSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        Rainning();

        // planet to spin on it's own axis
        //transform.Rotate(transform.up * PlanetRotateSpeed * Time.deltaTime);
        // planet to travel along a path that rotates around the sun
        //transform.RotateAround(Vector3.zero, Vector3.up, OrbitSpeed * Time.deltaTime);

        transform.Translate(0, 0, Mathf.Cos(tt) * 0.01f);
        t += 0.001f;
        tt += 0.03f;
    }


    GameObject g;
    void OnMouseDown()
    {
        g = Instantiate(water, this.transform.position * Random.Range(0.5f, 1.2f), this.transform.rotation) as GameObject;
    }


    //public Transform explosion;
    //Transform theClonedExplosion;
    void OnCollisionEnter()
    {
       // Destroy(gameObject);
       // theClonedExplosion = Instantiate(explosion, transform.position, transform.rotation) as Transform;
    }




    public void Rainning() {

        if (t > ((rainRate * btRainRate.value)-3))
        {
            t = 0;
            g = Instantiate(water, this.transform.position * Random.Range(0.5f, 1.2f) , this.transform.rotation) as GameObject;

            //GameObject obj = Instantiate(water, this.transform.position, this.transform.rotation) as GameObject;
            //obj.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            //obj.transform.up = GetComponent<Mesh>()[0].normals;
            //Debug.Log(hit.transform.position);
            //this.transform.position = hit.transform.position;
        }

    }



}
