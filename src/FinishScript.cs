﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public void Menu(){
        ChangeScene(0);
    }

    public void Restart(){
        ChangeScene(1);
    }
   
    void ChangeScene(int n){
     //The LoadScene method is used to start a scene
        SceneManager.LoadScene(n);
    }
}
