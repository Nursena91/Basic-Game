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
    public int objectsToDestroy = 5;
    public movingScript leveling;

    // Start is called before the first frame update
    void Start()
    {
        leveling = GameObject.FindGameObjectWithTag("countingObject").GetComponent<movingScript>();
        levels.Add(new DataScript(35,false,false));
        levels.Add(new DataScript(45,false,false));
        levels.Add(new DataScript(55,false,true));
        levels.Add(new DataScript(65,true,false));
        levels.Add(new DataScript(75,true,true));
        LoadLevel(indexOfLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int index){
        DataScript currentLevel = levels[index];
        if(currentLevel.newObject){
            //bomba objesini ekle
        }
        if(currentLevel.timeLimit){
            //zamanlayıcı koy
        }
    }

    public void isAllObjectsDestroyed(){        
        if(leveling.objectDestroyed==objectsToDestroy){
            leveling.objectDestroyed = 0;
            NextLevel();
        }
    }

    public void NextLevel(){
        indexOfLevel++;
        if(indexOfLevel<levels.Count){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Mevcut sahneyi yeniden yükleyerek resetle
            LoadLevel(indexOfLevel);
        }
    }

}
