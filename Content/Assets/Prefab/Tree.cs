using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tree : MonoBehaviour
{
    static public List<GameObject> treeList = new List<GameObject>();
    static public void GetTree(string treeType) {   
    }

    public GameObject timberSet = null;
    public GameObject landcover = null;
    public GameObject explo = null;
    public int numm = 0;
    Animation ani;
    Rigidbody rig;
    Collider coll;
    Renderer render;
    TextMesh meshText;
    int num = 10;
    int preNum = 14;

    void Awake()
    {
        //landcover = GameObject.FindGameObjectWithTag("landCoverA");
        //timberSet = GameObject.FindGameObjectWithTag("timberSet");
        meshText = gameObject.GetComponentInChildren<TextMesh>();
        ani = this.GetComponent<Animation>();
        rig = this.GetComponent<Rigidbody>();
        coll = this.GetComponent<Collider>();
        render = this.GetComponentInChildren<Renderer>();
        Tree.treeList.Add(gameObject);
        Debug.Log("tree num : " + Tree.treeList.Count.ToString());
    }
    void Start()
    {

        meshText.text = "Value: " + num;
        //meshText.fontSize = 3;
    }

    bool squareBar = true;
    bool updateBool = true;

    void Update()
    {
        if (updateBool)
        {
            if (!ani.IsPlaying("start"))
            {
                ani.Play("loop_01");
                updateBool = false;
            }
        }

        if (coll.bounds.max.y - 1f <= coll.bounds.min.y)
        {
            PopSquareBar();
            Destroy(gameObject);
        }
        if (preNum < num) PopulateLandCover();

 
   
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water"))
        {
            float s = other.gameObject.transform.localScale.x * 20f;
            num += (int)s;
            meshText.text = "Value: " + num;
            this.transform.localScale += (other.gameObject.transform.localScale * 0.2f);
            Factory.cabonLevel -= 5;
        }
        if (other.CompareTag("smallA") || other.CompareTag("sea"))
        {
            GameObject g = Instantiate(explo, this.transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }

    }

    private Color startcolor;

    void OnMouseEnter()
    {
        startcolor = render.material.color;
        render.material.color = Color.white;
        meshText.color = Color.black;
    }

    public void OnMouseExit()
    {
        render.material.color = startcolor;
        meshText.color = Color.white;
    }

    private Vector3 screenPoint;
    private Vector3 offset;

    public void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    public void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    public void OnDestroy()
    {
        Tree.treeList.Remove(gameObject);
    }

    public void PopulateLandCover()
    {
        Vector3 v = new Vector3(Random.Range(-1.2f, 1.2f) , 0, Random.Range(-1.2f, 1.2f));
        GameObject g = Instantiate(landcover, this.transform.position + v, Quaternion.identity) as GameObject;
        preNum = num;

    }

    public void PopSquareBar()
    {
        GameObject g = Instantiate(timberSet, this.transform.position, Quaternion.identity) as GameObject;
    }
}
