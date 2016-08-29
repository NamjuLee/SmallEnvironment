using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

    public float strength = 0.1f;

    void Update()
    {

        //this.transform.Translate(-0.3f * strength, 0f, 0f);
    }




    public Transform explosion;
    Transform theClonedExplosion;
    void OnCollisionEnter()
    {
        

        Destroy(gameObject);
        theClonedExplosion = Instantiate(explosion, transform.position, transform.rotation) as Transform;
    }


}
