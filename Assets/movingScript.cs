using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class movingScript : MonoBehaviour
{
    // Rigidbody2D bileşenini tutmak için bir değişken
    private Rigidbody2D rb;
    // Diğer değişkenler
    public int spinSpeed = 35;
    public float displayTime = 3.0f;
    public GameObject Obstacle;
    public GameObject Bomb;
    public int radius = 4;
    public int angle; 
    public int objectDestroyed = 0;
    public bool isInTrigger = false;
    public bool thisIsBomb = false;
    public int randomNumber;
    Vector3 anchorPoint;
    int spinDirection = 1;
    public DestroyScript deletingObstacles;
    public PositioningCircles addingObstacles;
    public LevelScript control;
    public DestroyBomb deletingBomb;
    void Start()
    {
        // Rigidbody2D bileşenine erişim
        AddObjects();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // Transform ile döndürme işlemi
        transform.RotateAround(anchorPoint, Vector3.forward, (spinSpeed * Time.deltaTime) * spinDirection);
        if (isInTrigger)
        {
            // Nesne trigger alanı içinde olduğu sürece bu kod her frame'de çalışır
            PerformContinuousAction();
        }else{
            if(Input.GetKeyDown(KeyCode.Space))
                control.FailedLevel();
        }
    }

        void OnTriggerEnter2D(Collider2D other)
    {

            isInTrigger = true; 
            Debug.Log("Nesne trigger alanına girdi.");
        
    }

    void OnTriggerExit2D(Collider2D other)
    {

            isInTrigger = false;          
            Debug.Log("Nesne trigger alanından çıktı.");
        
    }

    void PerformContinuousAction()
    {
        // Sürekli gerçekleştirmek istediğiniz işlemler burada
        Debug.Log("Trigger alanı içinde sürekli işlem yapılıyor.");
        if (Input.GetKeyDown(KeyCode.Space))
        {
                if(thisIsBomb){
                    control.FailedLevel();
                    thisIsBomb = false;
                }else{
                    objectDestroyed++;
                    deletingObstacles = GameObject.FindGameObjectWithTag("obstacles").GetComponent<DestroyScript>();
                    deletingObstacles.DestroyObject();
                    AddObjects();
                    spinDirection *= -1;
                    SpeedOfMovingObject();
                }

        }
    }

    /*
    private void OnTriggerStay2D(Collider2D collision) 
    {
        Debug.Log("sup");


    }
    */

    public void SpeedOfMovingObject(){
        if(objectDestroyed==0)
            spinSpeed = 35;
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

    public void AddObject(){

        angle = Random.Range(1,360);
        Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0f);
        Debug.Log("Radius: " + radius + " NewPos: " + newPos + " Angle: " + angle);
        Instantiate(Obstacle, newPos, Quaternion.identity);

    }
    
    public void AddBomb(){

        angle = Random.Range(1,360);
        Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0f);
        Debug.Log("Radius: " + radius + " NewPos: " + newPos + " Angle: " + angle);
        Instantiate(Bomb, newPos, Quaternion.identity);
        StartCoroutine(Disappear());

    }

    public void AddObjects(){
        control = GameObject.FindGameObjectWithTag("controlLevel").GetComponent<LevelScript>();
        if(control.useBomb){
            randomNumber = Random.Range(1,4);
            if(randomNumber == 2){
                AddBomb();
                thisIsBomb = true;
            }else{
                AddObject();
            }
        }else{
            AddObject();
        }
    }

    IEnumerator Disappear(){
        // Belirtilen süre boyunca bekle
        yield return new WaitForSeconds(displayTime);
        deletingBomb = GameObject.FindGameObjectWithTag("bomb").GetComponent<DestroyBomb>();
        deletingBomb.DestroyBombObject();
        thisIsBomb = false;
        AddObjects();
    }


}