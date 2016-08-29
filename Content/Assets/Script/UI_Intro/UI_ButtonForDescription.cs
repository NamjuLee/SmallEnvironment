using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_ButtonForDescription : MonoBehaviour {


    public GameObject rawImage;
	// Use this for initialization
	void Awake () {
      


    }
	
	// Update is called once per frame
	void Update () {
	
	}


    bool over = true;
    void OnMouseOver()
    {
        //over = true;
        if (over)
        {
            rawImage.GetComponent<Image>().enabled = true;
            Debug.Log("wwww");
            over = false;
        }

    }


    void OnMouseExit()
    {


        rawImage.GetComponent<Image>().enabled = false;
        over = true;
    }


}
