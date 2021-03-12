using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    Animator anim; //variable associated to the animator 
    [SerializeField]
    float moveSpeed=1.4f;
    [SerializeField]
    bool isJumping=false;
    [SerializeField]
    float jumpForce=5f;
    // Start is called before the first frame update
    void Start()
    {
        body=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        Jump();
        Fallen();
    }

    void Movement()
    {
        float h=Input.GetAxis("Horizontal"); //take the axes
        Vector2 velocity=new Vector2(Vector2.right.x*moveSpeed*h,body.velocity.y); //create the velocity Vector2
        body.velocity=velocity; //set the velocity to the velocity of the player

        if(velocity.x<0)
        {
            body.transform.localScale=new Vector3(-1,1,1); //change the direction of the sprite
        }else{
            body.transform.localScale=new Vector3(1,1,1); //change the direction of the sprite
        }
        anim.SetFloat("isMoving",Mathf.Abs(h)); //if the player is moving active the animation 
    }

    void Jump()
    {
        if(isJumping){ //Check if the player is jumping
            if(body.velocity.y==0){ //so if the body of player is not moving in y axis
                isJumping=false; //set this to false
            }
        }else{ //if is not jumping
            if(Input.GetAxis("Jump")>0){ //if the general key for jump is pressed (pc = spacebar)
                body.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse); //is added an impulse force to make the player jump
                isJumping=true; //so this now is true
            }
        }
    }

    void Fallen(){
        if(gameObject.transform.position.y < -3.2){ //check if the player is gone off the path
            Death(); //so kill the player
        }
    }

    private void OnCollisionEnter2D(Collision2D other){ //if there is a collision
        if(other.gameObject.tag == "Enemy"){ //if the collision is with an Enemy
            Death(); //so kill the player
        }
    }

    public void Death(){ //kill the player
        GetComponent<CircleCollider2D>().enabled = false; //disable the player hitbox
        GetComponent<BoxCollider2D>().enabled = false; //disable the player hitbox
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; //disable the player phisics
        GetComponent<PlayerCombat>().enabled = false; //disable the combat script
        anim.SetBool("isDead",true); //is setted the death animation
        this.enabled = false; //disable this script
        ChangeScene(3); //change the scene to the mission
    }

    void ChangeScene(int n){
        SceneManager.LoadScene(n);
    }
}
