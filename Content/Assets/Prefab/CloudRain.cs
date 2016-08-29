using UnityEngine;
using System.Collections;

public class CloudRain : MonoBehaviour {

    public GameObject water;
    public float rainRate = 10.0f;
    GameObject g;
    float t = 0.0f;

    // Use this for initialization
    void Start()
    {
        t = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > (t + rainRate))
        {
            t = Time.time;
            Instantiate(water, this.transform.position, this.transform.rotation);



            //GameObject obj = Instantiate(water, this.transform.position, this.transform.rotation) as GameObject;
            //obj.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            //obj.transform.up = GetComponent<Mesh>()[0].normals;
            //Debug.Log(hit.transform.position);
            //this.transform.position = hit.transform.position;
        }

    }
}
