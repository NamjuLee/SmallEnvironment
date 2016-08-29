using UnityEngine;
using System.Collections;

public class UIEasing : MonoBehaviour {


    public GameObject g;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
      this.transform.position = EasingMotion(this.transform.position , g.transform.position);
	}



    Vector3 EasingMotion(Vector3 v1 , Vector3 v2)
    {
       Vector3 v = v2 - v1;
       return  v1 + v * Mathf.Log(v.magnitude) * 0.1f;
    }

}
