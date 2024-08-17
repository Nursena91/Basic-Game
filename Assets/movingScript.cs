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
    public bool flag;
    public DestroyScript deletingObstacles;
    public PositioningCircles addingObstacles;
    void Start()
    {
        // Rigidbody2D bileşenine erişim
        deletingObstacles = GameObject.FindGameObjectWithTag("obstacles").GetComponent<DestroyScript>();
        addingObstacles = GameObject.FindGameObjectWithTag("addingObstacles").GetComponent<PositioningCircles>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        deletingObstacles = GameObject.FindGameObjectWithTag("obstacles").GetComponent<DestroyScript>();
        // Transform ile döndürme işlemi
        transform.RotateAround(anchorPoint, Vector3.forward, (spinSpeed * Time.deltaTime) * spinDirection);
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        Debug.Log("sup");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            deletingObstacles.DestroyObject();
            addingObstacles.AddObject();
            spinDirection *= -1;
            //destroy komutu ver ve klonu kaldır. yeniden addobject fonksiyonunu çağır.
            //ayrıca counter oluştur ve 3 kere addobject oluşturuluyorsa sonraki levela geçilsin.
        }else{
            //oyunu durdur ve baştan al.
        }
    }
}
