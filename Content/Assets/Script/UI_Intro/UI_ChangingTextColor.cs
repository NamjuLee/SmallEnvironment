using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_ChangingTextColor : MonoBehaviour {

    Text text;
	// Use this for initialization
	void Awake () {
       text = this.GetComponent<Text>();	    
	}

    float t = 0.0f;
	void Update () {


       // text.color = new Color(Mathf.Sin(t), Mathf.Cos(t) , Mathf.Sin(t), 0.5f);
        t += 0.01f;
	}



}
