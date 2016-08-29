using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Factory : MonoBehaviour {

    public static List<GameObject> factoryList = new List<GameObject>();

    public static int cabonLevel = 0;
    Renderer render;
    ParticleSystem particles;
    void Awake()
    {
        render = this.GetComponentInChildren<Renderer>();
        particles = this.GetComponentInChildren<ParticleSystem>();
        particles.enableEmission = false;
        Factory.factoryList.Add(gameObject);
    }


    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if (!particles.isPlaying) particles.enableEmission = false;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("timber") || other.CompareTag("landCoverA"))
        {
            particles.enableEmission = true;
            particles.Play();
            UIText.Money += 100;
            Factory.cabonLevel++;
            //particles.enableEmission = false;
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



}
