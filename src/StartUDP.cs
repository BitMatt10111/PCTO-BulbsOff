using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUDP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CursorCollide>().enabled=true;
        //Debug.Log("Fatto");
    }
}
