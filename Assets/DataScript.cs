using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataScript : MonoBehaviour
{
    //2.levelda sadece hız artacak (hız)
    //3.levelda bomba da gelecek (bomba,hız)
    //4.levelda süre olacak (süre, hız)
    //5.levelda hem süre hem bomba olacak (süre,bomba,hız)
    //spinspeed 
    //bomb
    //objecttodestroy
    //time
    // Start is called before the first frame update
    public int spinSpeedLevel;
    public bool timeLimit;
    public bool newObject;
    public DataScript (int spinSpeedLevel, bool timeLimit, bool newObject){
        this.spinSpeedLevel = spinSpeedLevel;
        this.timeLimit = timeLimit;
        this.newObject = newObject;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
