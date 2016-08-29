using UnityEngine;
using System.Collections;

public class UI_IntroLoadLevel : MonoBehaviour {

    public string sc;
    void OnMouseDown()
    {
        Application.LoadLevel(sc);
    }
}
