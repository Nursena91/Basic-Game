using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{


    public List<DataScript> levels = new List<DataScript>();
    private int indexOfLevel = 0;


    // Start is called before the first frame update
    void Start()
    {
        levels.Add(new DataScript(35,false,false));
        levels.Add(new DataScript(45,false,false));
        levels.Add(new DataScript(55,false,true));
        levels.Add(new DataScript(65,true,false));
        levels.Add(new DataScript(75,true,true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextLevel(){

    }

}
