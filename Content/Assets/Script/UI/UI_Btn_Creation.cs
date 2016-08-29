using UnityEngine;
using System.Collections;

public class UI_Btn_Creation : MonoBehaviour {

    public GameObject creation;
    public int cost;

    void OnMouseDrag()
    {
        Raycasting();
    }

    void OnMouseUp()
    {
        g = null;
    }

    GameObject g;
    private Vector3 screenPoint;
    private RaycastHit hit;
    public void Raycasting()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "land")
            {
                if (UIText.Money > cost)
                {
                    if ((UIText.Money - cost) >= 0)
                    {
                        UIText.Money -= cost;
                        if (g == null) g = Instantiate(creation, Vector3.one, Quaternion.identity) as GameObject;
                        g.transform.position = hit.point;
                    }
                }
            }
        }
    }

}
