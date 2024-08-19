using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{

    public Text levelText;
    public List<DataScript> levels = new List<DataScript>();
    public static int indexOfLevel = 0;
    public bool useBomb = false;
    public int objectsToDestroy = 5;
    public movingScript leveling;

    // Start is called before the first frame update
    void Start()
    {
        leveling = GameObject.FindGameObjectWithTag("countingObject").GetComponent<movingScript>();
        levels.Add(new DataScript(100,false,false));
        levels.Add(new DataScript(45,true,true));
        levels.Add(new DataScript(55,false,true));
        levels.Add(new DataScript(65,true,true));
        LoadLevel(indexOfLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int index){
        LevelNumber();
        DataScript currentLevel = levels[index];
        //currentLevel.spinSpeedLevel = leveling.spinSpeed;
        if(currentLevel.newObject){
            useBomb = true;
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
        }
    }

    public void FailedLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Mevcut sahneyi yeniden yükleyerek resetle
    }

    public void LevelNumber() {
        levelText.text = (indexOfLevel + 1).ToString();
    }
}