using UnityEngine;
using System.Collections;

public class UI_BtnBuildingA : MonoBehaviour {



    void OnMouseDown()
    {
        Landscape.type = "buildingA";
        Landscape.creationExecutionFloat = 0.0f;
        Landscape.creationExecutionBool = false;
    }


    

}
