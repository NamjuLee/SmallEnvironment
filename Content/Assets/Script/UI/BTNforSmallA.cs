using UnityEngine;
using System.Collections;

public class BTNforSmallA : MonoBehaviour {

	// Use this for initialization
	void Start () {
        g = GameObject.FindGameObjectsWithTag("smallA");
    }
	
	// Update is called once per frame
	void Update () {
        	
	}

    GameObject[] g;
    void OnMouseDown()
    {
      foreach(GameObject gg in g)
        {
            gg.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
