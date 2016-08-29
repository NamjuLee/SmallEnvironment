using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BTN_UIForGravity : MonoBehaviour {

    public GameObject planet;
    public float dustScale = 4.0f;
    Text textGravity;
    Scrollbar dustLevel;
    // Use this for initialization
    void Awake()
    {
        dustLevel = this.GetComponent<Scrollbar>();
        textGravity = GameObject.Find("TextDateTop").GetComponent<Text>();

    }

    // Update is called once per frame
    //void Update()
   
    void OnGUI()
    {
        float val = (-dustLevel.value * 20f) + 0.1f; // - 0.5f;
        //float val = dustLevel.value * dustScale;
        //Debug.Log(val);
        planet.GetComponent<SMALLAGravityAttractor>().gravity = val;
        textGravity.text = "Gravity :  " + val.ToString();
        //dustP.startSize = size;

    }


}
