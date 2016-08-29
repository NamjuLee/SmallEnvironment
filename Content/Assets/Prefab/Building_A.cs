using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building_A : MonoBehaviour {

    public static List<GameObject> BuildingAList = new List<GameObject>();

    //public GameObject gameObject;

    Animation ani;
    Rigidbody rig;
    Collider coll;
    Renderer render;
    //TextMesh meshText;
    int num = 10;
    int preNum = 14;
    void Awake()
    {
        
        //timberSet = GameObject.FindGameObjectWithTag("timberSet");
        //   meshText = gameObject.GetComponentInChildren<TextMesh>();
        ani = this.GetComponent<Animation>();
        rig = this.GetComponent<Rigidbody>();
        coll = this.GetComponent<Collider>();
        render = this.GetComponentInChildren<Renderer>();
        Building_A.BuildingAList.Add(gameObject);
        //Debug.Log("tree num : " + Tree.treeList.Count.ToString());
    }


    public void GetBuilding() {

    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("smallA") || other.CompareTag("sea"))
        {

            Destroy(gameObject);
        }

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
        Building_A.BuildingAList.Remove(gameObject);
    }


}
