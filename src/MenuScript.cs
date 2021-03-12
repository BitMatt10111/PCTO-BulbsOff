using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] Image simbolsKey;
    [SerializeField] private bool ok=true;

    public void Play(){
        ChangeScene();
    }

    public void Quit(){
        Application.Quit();
    }

    public void Rules(){
         ok=!ok;
        simbolsKey.enabled=ok;
    }

    void ChangeScene(){
        SceneManager.LoadScene(1);
    }
}
