using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class movingScript : MonoBehaviour
{
    // Start is called before the first frame update
    int spinSpeed=70;
    Vector3 anchorPoint;
    int spinDirection = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(anchorPoint, Vector3.forward, (spinSpeed * Time.deltaTime) * spinDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (Input.GetKeyDown(KeyCode.Space)){
                spinDirection *= -1 ;
        }
    }
}
