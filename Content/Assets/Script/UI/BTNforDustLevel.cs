using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BTNforDustLevel : MonoBehaviour {

    public ParticleSystem dustP;
    public float dustScale = 4.0f;
    Scrollbar dustLevel;
	// Use this for initialization
	void Awake () {
        dustLevel = this.GetComponent<Scrollbar>();


    }
	
	// Update is called once per frame
	void Update () {
        //float val = dustLevel.value * dustScale;
        //Debug.Log(val);
        dustP.emissionRate = dustLevel.value * dustScale;
        //dustP.startSize = size;
        
	}
}
