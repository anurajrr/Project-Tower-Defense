using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinatesLabel : MonoBehaviour
{   
    TextMeshPro cordinatetext;
    Vector2Int cordinatepos = new Vector2Int();
     void Awake() 
    {
        cordinatetext = GetComponent<TextMeshPro>();
        Displaycordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            Displaycordinates();
            UpdateObjectCordinatesName();
        }
    }

     void Displaycordinates()
    {
        cordinatepos.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        cordinatepos.y = Mathf.RoundToInt(transform.parent.position.z/ UnityEditor.EditorSnapSettings.move.z);
        cordinatetext.text = cordinatepos.x + "," + cordinatepos.y;
    }

    private void UpdateObjectCordinatesName()
    {
        transform.parent.name = cordinatepos.ToString();
    }
}
