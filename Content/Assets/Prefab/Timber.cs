using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Timber : MonoBehaviour {

    static public List<GameObject> TimberList = new List<GameObject>();

    Animation ani;
    Rigidbody rig;
    Collider coll;
    Renderer render;

    int num = 10;
    int preNum = 14;
    void Awake()
    {
        //pop = GameObject.FindGameObjectWithTag("landCoverA");
        //timberSet = GameObject.FindGameObjectWithTag("timberSet");

        ani = this.GetComponent<Animation>();
        rig = this.GetComponent<Rigidbody>();
        coll = this.GetComponent<Collider>();
        render = this.GetComponentInChildren<Renderer>();
        Timber.TimberList.Add(gameObject);

    }




    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("smallA") || other.CompareTag("factory") || other.CompareTag("sea"))
        {

            Destroy(gameObject);
        }

    }




    private Color startcolor;
    void OnMouseEnter()
    {
        startcolor = render.material.color;
        render.material.color = Color.white;
    }
    void OnMouseExit()
    {
        render.material.color = startcolor;
    }





    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
    void OnDestroy()
    {
        Timber.TimberList.Remove(gameObject);
    }


}
