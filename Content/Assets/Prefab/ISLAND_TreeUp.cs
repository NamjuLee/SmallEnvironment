using UnityEngine;
using System.Collections;

public class ISLAND_TreeUp : MonoBehaviour {

    Rigidbody rg;
    void Awake () {
	 rg = this.GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
       rg.freezeRotation = true;
	}
}
