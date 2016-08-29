using UnityEngine;
using System.Collections;

public class BTNforFlood : MonoBehaviour {


    public GameObject sea;
    WaterProDayAni w;
    bool b;

    void Awake() {
        //g =  GameObject.Find("WaterProDaytime"); //.GetComponent<WaterProDayAni>().toggle;
        w = sea.GetComponent<WaterProDayAni>();
        b = w.toggle;
    }

    void OnMouseDown()
    //void OnGUI()
    {
        b = !b;
        w.toggle = !w.toggle;
        Debug.Log(b);
    }

}
