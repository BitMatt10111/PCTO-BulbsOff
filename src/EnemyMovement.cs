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
        if(MoveRight){ //if this is true
            transform.Translate(2*Time.deltaTime*speed,0,0); //move the enemy to right
            transform.localScale=new Vector2(1,1); //rotate the sprite
        }else{
            transform.Translate(-2*Time.deltaTime*speed,0,0); //move the enemy to right
            transform.localScale=new Vector2(-1,1); //rotate the sprite
        }
    }

    private void OnTriggerEnter2D(Collider2D trig) { //if collide
        if(trig.gameObject.CompareTag("Collider")){ //with an object tgged "Collider"
            if(MoveRight){ //change the value of the variable
                MoveRight=false;
            }else{
                MoveRight=true;
            }
        }
    }
}
