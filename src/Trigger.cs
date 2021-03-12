//These are the libraries used in unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    //this method is invoked when two objects with a hitbox overlap and the "ChangeScene" method is called.
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            ChangeScene();
        }
    }
    //This method is used to change the scene
     void ChangeScene(){
         //The LoadScene method is used to start a scene  
         SceneManager.LoadScene(2);
     }
     
}
