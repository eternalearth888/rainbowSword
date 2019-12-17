using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject playerObj;
    private Vector3 playerPos;
    public float MoveSpeed;
    public float MaxDist;
    public float MinDist;
    public float aggro = 20f;
    public float attDamage = 10f;
    private Animator anim;
    
    private float attackCooldown = 4f;
    public float attackDelay = 4f;
    public float hitRange = 5f;

    // Enemy Stats
    public float maxHealth = 100;
    private float currentHealth;
    private bool isPoisoned = false;
    private float poisonTick;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Bo");
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerObj.transform.position;
        transform.LookAt(playerPos);
        if(Vector3.Distance(transform.position, playerPos) >= aggro){
            return;
        }

        if(Vector3.Distance(transform.position, playerPos) >= MinDist){
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            //activate walking animation here
            anim.SetBool("Run Forward", true);
            //Debug.Log("Walking");
        }
        if(Vector3.Distance(transform.position, playerPos) <= MaxDist){
            anim.SetBool("Run Forward", false);
            //call attacking code here
            if(attackCooldown >= attackDelay){
                attackCooldown = 0f;
                anim.CrossFade("Stab Attack", 0);
                Attack();
                //Debug.Log("Attacking");
            }
        }
        attackCooldown += Time.deltaTime;

        if(isPoisoned){
            currentHealth -= 2.5f;
            poisonTick -= Time.deltaTime;
            if(poisonTick <= 0){
                isPoisoned = false;
            }
        }
    }

    void Attack(){
        //make attack attempt here
        if(Vector3.Distance(transform.position, playerPos) <= hitRange){
            // call damage functions in PlayerStats here
            //PlayerStats.TakeDamage(attDamage);
            playerObj.GetComponent<PlayerStats>().TakeDamage(attDamage);
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Sword"){
            if(PlayerController.isAttacking){
                TakeDamage();
                PlayerController.isAttacking = false;
            } 
        }
    }

    void TakeDamage(){
        Debug.Log("taking damage");
        //Red sword damage
        if(SwordSwapper.selectedSword == 0){
            currentHealth -= 50;
            //damage the player as well
        }
        //Orange sword damage
        else if(SwordSwapper.selectedSword == 1){
            currentHealth -= 10;
        }
        //Yellow Sword Damage
        else if(SwordSwapper.selectedSword == 2){
            currentHealth -= 25;
        }
        //Green Sword Damage
        else if(SwordSwapper.selectedSword == 3){
            currentHealth -= 12.5f;
            isPoisoned = true;
            poisonTick = 3f;
        }
        //Blue sword damage
        else if(SwordSwapper.selectedSword == 4){
            currentHealth -= 10;
        }
        //Purple sword damage
        else{
            currentHealth -= 12.5f;
        }
        //death case
        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }

}
