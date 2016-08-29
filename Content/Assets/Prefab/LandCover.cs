using UnityEngine;
using System.Collections;

public class LandCover : MonoBehaviour
{

    Animation ani;
    Rigidbody rig;
    Collider coll;
    Renderer render;


    void Awake()
    {

        ani = this.GetComponent<Animation>();
        rig = this.GetComponent<Rigidbody>();
        coll = this.GetComponent<Collider>();
        render = this.GetComponentInChildren<Renderer>();
        Tree.treeList.Add(gameObject);
        Debug.Log("tree num : " + Tree.treeList.Count.ToString());
    }

    
    



    void Start()
    {

        //meshText.fontSize = 3;
    }

    bool updateBool = true;
    bool populate = false;
    int num = 10;
    int preNum = 14;

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

        if (coll.bounds.max.y - 0.01f <= coll.bounds.min.y) Destroy(gameObject);


    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water"))
        {
            float s = other.gameObject.transform.localScale.x * 1f;
            num += (int)s;
           // meshText.text = "Value: " + num;
            gameObject.transform.localScale += (other.gameObject.transform.localScale * 0.2f);
        }
        if (other.CompareTag("smallA") || other.CompareTag("factory"))
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
        Tree.treeList.Remove(gameObject);
    }








}
