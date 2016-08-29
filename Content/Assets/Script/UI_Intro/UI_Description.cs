using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Description : MonoBehaviour {

    public bool theToggle;

    GameObject g;
	// Use this for initialization
	void Awake () {
	

	}

    void Update()
    {
        ToggleImage();
    }

        void ToggleImage() {

        this.GetComponent<Image>().enabled = theToggle;

    }



}
