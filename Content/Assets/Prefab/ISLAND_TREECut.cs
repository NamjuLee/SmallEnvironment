using UnityEngine;
using System.Collections;

public class ISLAND_TREECut : MonoBehaviour {

    Tree treeObj;

    public void Awake() {
        treeObj = this.GetComponent<Tree>();

    }


    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("timber"))
        {
            treeObj.PopSquareBar();
            treeObj.OnDestroy();
            Destroy(gameObject);
        }

    }
}
