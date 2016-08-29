using UnityEngine;
using System.Collections;

public class UI_Intro : MonoBehaviour {

    void OnGUI() {

        if (GUI.Button(new Rect((Screen.width / 2) - 75, (Screen.height / 2), 150, 200), "play video")) Application.LoadLevel("video");

    }


}
