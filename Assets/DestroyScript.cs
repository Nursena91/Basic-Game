using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public LevelScript control;


    // Start is called before the first frame update
    void Start()
    {       
        control = GameObject.FindGameObjectWithTag("controlLevel").GetComponent<LevelScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DestroyObject(){
        Destroy(gameObject);
        control.isAllObjectsDestroyed();
    }
}
