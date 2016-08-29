using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Water : MonoBehaviour
{

    public static List<GameObject> waterList = new List<GameObject>();
    

    int num;
    Renderer render;
    TextMesh meshText;
    Transform transParent;
    // Use this for initialization
    void Awake()
    {
        render = this.GetComponentInChildren<Renderer>();
        meshText = gameObject.GetComponentInChildren<TextMesh>();
        transParent = gameObject.GetComponentInParent<Transform>();

        startcolor = render.material.color;
        num = Random.Range(-5, 5);
        this.transform.localScale += new Vector3(num * 0.01f, num * 0.01f, num * 0.01f);


        Water.waterList.Add(gameObject);
        //Debug.Log("water num : " + Water.waterList.Count.ToString());


    }
    void Start() {

        meshText.text = "Value: " + num;
    }



    // Update is called once per frame
    void Update()
    {
    
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("treeA") || other.CompareTag("treeB") || other.CompareTag("treeC") || other.CompareTag("smallA") || other.CompareTag("landCoverA"))
        {
            //this.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            Destroy(gameObject);
        }
        else if (other.CompareTag("water"))
        {
            // this.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            //  waterList.Remove(this);
            // Destroy(other.gameObject);
        }
        if (other.CompareTag("smallA") || other.CompareTag("sea"))
        {

            Destroy(gameObject);
        }
    }


    private Color startcolor;
    void OnMouseEnter()
    {
        
        render.material.color = Color.white;
        meshText.color = Color.black;
        
    }
    void OnMouseExit()
    {
        render.material.color = startcolor;
        meshText.color = startcolor;//Color.white;
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
        Water.waterList.Remove(gameObject);
    }









}