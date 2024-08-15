using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class movingScript : MonoBehaviour
{
    // Rigidbody2D bileşenini tutmak için bir değişken
    private Rigidbody2D rb;
    
    // Diğer değişkenler
    int spinSpeed = 70;
    Vector3 anchorPoint;
    int spinDirection = 1;

    void Start()
    {
        // Rigidbody2D bileşenine erişim
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Transform ile döndürme işlemi
        transform.RotateAround(anchorPoint, Vector3.forward, (spinSpeed * Time.deltaTime) * spinDirection);
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        Debug.Log("sup");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Dönüş yönünü tersine çevir
            spinDirection *= -1;
        }
    }
}
