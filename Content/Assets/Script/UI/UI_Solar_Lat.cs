using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Solar_Lat : MonoBehaviour {

    Scrollbar bar;

    void Awake()
    {
        bar = gameObject.GetComponent<Scrollbar>();
        bar.value  = 90;
    }

    void Start()
    {
        bar = gameObject.GetComponent<Scrollbar>();
        bar.value = 35;
    }

    void OnEnable()
    {
        bar = gameObject.GetComponent<Scrollbar>();
        bar.value = 1;
    }







}
