using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            ChangeScene();
        }
    }

     void ChangeScene(){
         SceneManager.LoadScene(2);
     }
     
}