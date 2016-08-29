using UnityEngine;
using System.Collections;

public class WaterProDayAni : MonoBehaviour {
    public bool toggle = false;
    public float height;
    float initheight;
    int duration = 0;

    void Awake () {
        initheight = this.transform.position.y;

    }

	void Update () {

        if(duration > 90) toggle = false;
        if (toggle) WaterRaise();
        else WaterDown();

    }

    void WaterRaise() {

        if (transform.position.y < height)
        {
            transform.Translate(0, 0.006f, 0);
        }
        else
        {
            duration++;
        }

    }
    void WaterDown()
    {
        if (transform.position.y > initheight)
        {
            transform.Translate(0, -0.008f, 0);
            duration = 0;
        }

    }
}
