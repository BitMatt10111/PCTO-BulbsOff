using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    
    public Transform attackPoint;

    public Vector2 attackRange = new Vector2(2f,5f);

    public float angle = 90f;

    public LayerMask enemyLayers;

    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Attack();
        }
    }

    void Attack(){
        //sound sword
        //SoundManagerScript.PlaySound("SoundSwordEffect");
        //Animazione attacco
        animator.SetTrigger("Attack");
        //Capire se ci sono nemici nel range dell'attacco
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, attackRange, angle, enemyLayers);       //crea un cerchio vuoto intorno alla spada che rileva i nemici al suo interno
        //Ucciderli
        foreach(Collider2D enemy in hitEnemies){
            //Debug.Log("We hit " + enemy.name);     scrive sulla console il nemico ucciso
            enemy.GetComponent<Collider2D>().enabled = false;
            enemy.GetComponent<SpriteRenderer>().enabled = false;            
        }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireCube(attackPoint.position, attackRange);
        
    }

}