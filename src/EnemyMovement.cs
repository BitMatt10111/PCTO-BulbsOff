using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public bool MoveRight;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(MoveRight){
            transform.Translate(2*Time.deltaTime*speed,0,0);
            transform.localScale=new Vector2(1,1);
        }else{
            transform.Translate(-2*Time.deltaTime*speed,0,0);
            transform.localScale=new Vector2(-1,1);
        }
    }

    private void OnTriggerEnter2D(Collider2D trig) {
        if(trig.gameObject.CompareTag("Collider")){
            if(MoveRight){
                MoveRight=false;
            }else{
                MoveRight=true;
            }
        }
    }
}
