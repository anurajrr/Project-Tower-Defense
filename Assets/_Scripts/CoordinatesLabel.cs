using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinatesLabel : MonoBehaviour
{   
    [SerializeField] Color defaultcolor = Color.cyan;
    [SerializeField] Color blockedcolor = Color.gray;
    TextMeshPro cordinatetext;
    Vector2Int cordinatepos = new Vector2Int();
    Waypoint waypoint;
     void Awake() 
    {
        cordinatetext = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
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
            ColorCordinates();
    }

    private void ColorCordinates()
    {
        if(waypoint.IsPlacable)
        {
            cordinatetext.color = defaultcolor;
        }
        else
        {
            cordinatetext.color = blockedcolor;
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
