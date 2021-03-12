using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    //these methods are associated with buttons, the menu method takes you to the menu scene and the restart method takes you to the start of the game.
    public void Menu(){
        ChangeScene(0);
    }

    public void Restart(){
        ChangeScene(1);
    }
   //This method is used to change the scene
    void ChangeScene(int n){
     //The LoadScene method is used to start a scene
        SceneManager.LoadScene(n);
    }
}
