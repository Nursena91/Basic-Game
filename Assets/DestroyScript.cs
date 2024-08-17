using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public LevelScript nextlevel;

    // Start is called before the first frame update
    void Start()
    {       
        nextlevel = GameObject.FindGameObjectWithTag("countingObject").GetComponent<LevelScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DestroyObject(){
        Destroy(gameObject);
    }
}
