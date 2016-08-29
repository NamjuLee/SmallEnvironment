using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIText : MonoBehaviour {
    public static int Money = 0; 
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "CARBON LEVEL : " + Factory.cabonLevel +
                                    "  |   WATER : " + Water.waterList.Count.ToString() +
                                    "  |   TREE : " + Tree.treeList.Count.ToString() +
                                    "  |   TIMBER : " + Timber.TimberList.Count.ToString() +
                                    "  |   RESOURCE : " + UIText.Money;
    }
}
