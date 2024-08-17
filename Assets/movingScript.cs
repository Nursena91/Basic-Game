using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class movingScript : MonoBehaviour
{
    // Rigidbody2D bileşenini tutmak için bir değişken
    private Rigidbody2D rb;
    // Diğer değişkenler
    int spinSpeed = 35;
    int objectDestroyed = 0;
    int objectToDestroy = 5;
    Vector3 anchorPoint;
    int spinDirection = 1;
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
            objectDestroyed++;
            deletingObstacles.DestroyObject();
            addingObstacles.AddObject();
            spinDirection *= -1;
            SpeedOfMovingObject();
            //5 kere addobject oluşturuluyorsa sonraki levela geçilsin.
        }else{
            //oyunu durdur ve baştan al.
        }
    }

    private void SpeedOfMovingObject(){
        if(objectDestroyed==1)
            spinSpeed = 45;
        if(objectDestroyed==2)
            spinSpeed = 55;
        if(objectDestroyed==3)
            spinSpeed = 65;
        if(objectDestroyed==4)
            spinSpeed = 75;
        if(objectDestroyed==5)
            spinSpeed = 85;
    }

}
