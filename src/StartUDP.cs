using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUDP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CursorCollide>().enabled=true; //when the scene start the UDP reciver code is set to true
        //this instruction remove the lag on the platform gameplay
    }
}
