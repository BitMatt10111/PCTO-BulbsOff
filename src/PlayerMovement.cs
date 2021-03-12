using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    Animator anim;
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
        float h=Input.GetAxis("Horizontal");
        Vector2 velocity=new Vector2(Vector2.right.x*moveSpeed*h,body.velocity.y);
        body.velocity=velocity;

        if(velocity.x<0)
        {
            body.transform.localScale=new Vector3(-1,1,1);
        }else{
            body.transform.localScale=new Vector3(1,1,1);
        }
        anim.SetFloat("isMoving",Mathf.Abs(h));
    }

    void Jump()
    {
        if(isJumping){
            if(body.velocity.y==0){
                isJumping=false;
            }
        }else{
            if(Input.GetAxis("Jump")>0){
                body.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
                isJumping=true;
            }
        }
    }

    void Fallen(){
        if(gameObject.transform.position.y < -3.2){
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy"){
            Death();
        }
    }

    public void Death(){
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<PlayerCombat>().enabled = false;
        anim.SetBool("isDead",true);
        this.enabled = false;
        ChangeScene(3);
    }

    void ChangeScene(int n){
        SceneManager.LoadScene(n);
    }
}
