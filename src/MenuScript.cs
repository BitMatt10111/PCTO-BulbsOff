using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] Image simbolsKey;
    [SerializeField] private bool ok=true;
    
    //these three methods are associated with buttons in the game menu
    //The play method makes the scene change 
    public void Play(){
        ChangeScene();
    }
    //this method closes the game
    public void Quit(){
        Application.Quit();
    }
    //this method is used to make an image appear in the game if pressed and remove it if pressed again
    public void Rules(){
         ok=!ok;
        simbolsKey.enabled=ok;
    }

    void ChangeScene(){
        SceneManager.LoadScene(1);
    }
}
