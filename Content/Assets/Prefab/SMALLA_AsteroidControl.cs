using UnityEngine;
using System.Collections;

public class SMALLA_AsteroidControl : MonoBehaviour {


    public GameObject g;
    public float probabity;

    // Use this for initialization
    void Awake () {

        //g = Instantiate(Resources.Load("asteroid")) as GameObject;
	}

    float t = 0.0f;
	// Update is called once per frame
	void Update () {

        if (t > probabity) {
            //Vector3 vec = new Vector3(transform.position.x + 15, transform.position.y, transform.position.z + 12);
            GameObject gg = Instantiate(g, transform.position * Random.RandomRange(-1.5f, 1.5f), this.transform.rotation) as GameObject;


            //Instantiate(g, Vector3.)
            t = 0.0f;
        }
        t += 0.01f;
	}
}
