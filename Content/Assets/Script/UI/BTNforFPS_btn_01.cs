using UnityEngine;
using System.Collections;

public class BTNforFPS_btn_01 : MonoBehaviour
{

    void Awake() {


    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            CallScene();
        }
    }


    public string sc;
    void CallScene()
    {

            

        Application.LoadLevel(sc);
    }


}