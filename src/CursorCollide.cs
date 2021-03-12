using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class CursorCollide : MonoBehaviour
{
    //[SerializeField] Vector2 v;
    GameObject cursor;
    //here are all the variables that we use in the mission
    [SerializeField] GameObject imgB1;
    [SerializeField] GameObject imgB2;
    [SerializeField] GameObject imgR1;
    [SerializeField] GameObject imgR2;
    [SerializeField] GameObject imgG1;
    [SerializeField] GameObject imgG2;
    [SerializeField] GameObject imgY1;
    [SerializeField] GameObject imgY2;
    [SerializeField] GameObject appoggio;
    [SerializeField] bool red=false;
    [SerializeField] bool green=false;
    [SerializeField] bool blue=false;
    [SerializeField] bool yellow=false;
    [SerializeField] int rounds=0;

    UdpClient client;
 
    // public
    // public string IP = "127.0.0.1"; default local
    public int port=8051; // define > init 
    
    void Start(){
        cursor = GameObject.Find("Puntatore");
        client = new UdpClient(port);
    }

    void FixedUpdate(){
        //here I take the bytes of the socket sent by the python program in an array of bytes
        IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
        byte[] data = client.Receive(ref anyIP);
        //in a float vector I take the bytes converted to float by the function:
        float[] floatData = ConvertByteToFloat(data);
        //mapping the values for the main camera 
        float x=floatData[0]*10.5f/500;
        float y=floatData[1]*(-5.5f)/500;
        //print(x + "," + y);

        //v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //set the cursor in the middle of the main camera and i check the five rounds of the game
        if(x == 0 && y == 0){
            cursor.transform.position= new Vector2(5,-3);
        }else{
            cursor.transform.position= new Vector2(x,y);
        }
        if(blue==false && red==false && yellow==false && green==false){
            RandomImage();
        }
        if(rounds>=5){
            ChangeScene();
            GetComponent<CursorCollide>().enabled=false;
        }
        //Debug.Log(v);
    }
    
    void ChangeScene(){
        SceneManager.LoadScene(3);
    }
    //in this function I check whether the colliders overlap, the cursor with the buttons. and I also increase the rounds
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("BlueBtn") || other.CompareTag("GreenBtn") || other.CompareTag("RedBtn") || other.CompareTag("YellowBtn")){
            if (other.CompareTag("BlueBtn")){
                if(blue==true){
                    Debug.Log("Correct");
                }else{
                    Debug.Log("Uncorrect");
                }
            }else if (other.CompareTag("GreenBtn")){
                if(green==true){
                    Debug.Log("Correct");
                }else{
                    Debug.Log("Uncorrect");
                }
            }else if (other.CompareTag("RedBtn")){
                if(red==true){
                    Debug.Log("Correct");
                }else{
                    Debug.Log("Uncorrect");
                }
            }else if (other.CompareTag("YellowBtn")){
                if(yellow==true){
                    Debug.Log("Correct");
                }else{
                    Debug.Log("Uncorrect");
                }
            }
            blue=false;
            green=false;
            red=false;
            yellow=false;
            appoggio.GetComponent<SpriteRenderer>().enabled = false;
            rounds++;
        }
    }
    //in this function I randomise the image of the mission
    void RandomImage(){
        //I randomise a number from 1 to 8 in a variable that I control and according to the number I assign an image
        int numRand = (int) UnityEngine.Random.Range(1,9);
        if(numRand == 1 ){
            appoggio = imgB1;
            blue=true;
        }else if(numRand == 2){
            appoggio = imgB2;
            blue=true;
        }else if(numRand == 3){
            appoggio = imgR1;
            red=true;
        }else if(numRand == 4){
            appoggio = imgR2;
            red=true;
        }else if(numRand == 5){
            appoggio = imgY1;
            yellow=true;
        }else if(numRand == 6){
            appoggio = imgY2;
            yellow=true;
        }else if(numRand == 7){
            appoggio = imgG1;
            green=true;
        }else{
            appoggio = imgG2;
            green=true;
        }
        //when I have randomised the image I make it appear on the screen
        appoggio.GetComponent<SpriteRenderer>().enabled = true;
    }
    //In this function you transform the bytes passed via parameter into floats, the function returns an array of floats
    public static float[] ConvertByteToFloat(byte[] array) {
        float[] floatArr = new float[array.Length / 4];
        for (int i = 0; i < floatArr.Length; i++) {
            floatArr[i] = BitConverter.ToSingle(array, i * sizeof(Single));
        }
        return floatArr;
    }
}
