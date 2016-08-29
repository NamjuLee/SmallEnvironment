using UnityEngine;
using System.Collections;

public class UI_ToMainMenu : MonoBehaviour {

    void OnMouseDown()
    {
        Application.LoadLevel("Sc_1_Intro");
    }
}
