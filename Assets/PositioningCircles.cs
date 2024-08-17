using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PositioningCircles : MonoBehaviour
{
    public GameObject Obstacle;
    public int radius = 4;
    public int angle; 

    // Start is called before the first frame update
    void Start()
    {
        AddObject();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void AddObject(){

        angle = Random.Range(1,360);
        Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0f);
        Debug.Log("Radius: " + radius + " NewPos: " + newPos + " Angle: " + angle);
        Instantiate(Obstacle, newPos, Quaternion.identity);

    }

}
