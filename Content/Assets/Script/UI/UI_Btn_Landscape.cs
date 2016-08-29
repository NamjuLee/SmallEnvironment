using UnityEngine;
using System.Collections;

public class UI_Btn_Landscape : MonoBehaviour {

    void OnMouseDown()
    {
        Landscape.landPixelpBool = !Landscape.landPixelpBool;
        Debug.Log(Landscape.landPixelpBool);
    }

}
