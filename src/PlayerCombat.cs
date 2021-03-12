using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator; //Animator instance, Animator is used to activate animations in the game, e.g. in our game the movement of the sword
    
    public Transform attackPoint; //attackPoint is an instance of Transform

    public Vector2 attackRange = new Vector2(2f,5f); //Vector of 2 elements, usually used for 2D games to know the positions of x and y or in this case for the size of the attachment, the two sides of a rectangle of the attachment box

    public float angle = 90f; 

    public LayerMask enemyLayers; //instantiate enemuLayers to have an enemy-specific layer

    

    // Update is called once per frame
    //this method always checks if the left mouse button is pressed, if pressed it invokes the Attack() method, interaction with the player in the game
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Attack();
        }
    }

    void Attack(){      
        animator.SetTrigger("Attack"); ////the SetTrigger method is used to activate the Attack animation, the animation in the game are sprites placed at a specific time, i.e. when the method is invoked on the screen you can see the character change position, in this case attack with a sword
        //Capire se ci sono nemici nel range dell'attacco
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, attackRange, angle, enemyLayers);   //Collider2D[] si crea un rettangolo vuoto intorno alla spada e si rileva se ci sono nemici e Physics2D.OverlapBoxAll() ti restituisce tutti i Collider che trova, i collider sono una “classe” che oggetto che deve interagire con qualcosa che deve esserci
        //foreach is a for that runs through the list from before to kill enemies
        foreach(Collider2D enemy in hitEnemies){
            //the layer we instantiated earlier allows us via the GetComponent method to "take" the elements of the enemy and deactivate them with the enabled method
            enemy.GetComponent<Collider2D>().enabled = false;
            enemy.GetComponent<SpriteRenderer>().enabled = false;            
        }
    }
    //this method is only invoked if the script is connected to the object in the scene
    //This method is a unity method and is usually used for visual debugging.
    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        //The DrawWireCube method is a method that creates a box around the attack, for which the values are given as the centre or attackPoint.position and the size attackRange
        Gizmos.DrawWireCube(attackPoint.position, attackRange);
        
    }

}
