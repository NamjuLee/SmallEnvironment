using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EasingMotion : MonoBehaviour {


    public float min = 100f;

    RectTransform g;
    Vector2 v;
    Vector2 vv;
    bool move = false;
    bool flip = true;
    void Awake() {
        g = this.transform.parent.GetComponent<RectTransform>();
        v = new Vector2(g.localPosition.x -1.5f, g.localPosition.y);
        vv = new Vector2(g.localPosition.x + min, g.localPosition.y);
    }

    void Update()
    {

        if (move)
        {
            if (flip)
            {
                g.localPosition = Easing(g.localPosition, vv);
                if ((new Vector2(g.localPosition.x, g.localPosition.y) - vv).magnitude < 1.5f)
                {
                    move = false;
                    flip = false;
                }
            }
            else
            {
                g.localPosition = Easing(g.localPosition, v);
                if ((new Vector2(g.localPosition.x, g.localPosition.y) - v).magnitude < 1.5f)
                {
                    move = false;
                    flip = true;
                }
            }
        }



    }


    void OnMouseDown()
    {
        move = true;
    }


    Vector3 Easing(Vector2 v1, Vector2 v2)
    {
        Vector2 v = v2 - v1;
        return v1 + v * Mathf.Log(v.magnitude) * 0.03f;
    }




}
