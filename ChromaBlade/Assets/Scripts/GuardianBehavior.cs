using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianBehavior : MonoBehaviour
{
    private GameObject playerObj;
    private Vector3 playerPos;
    public float MoveSpeed;
    public float MaxDist;
    public float MinDist;
    public float aggro = 50f;
    public float attDamage = 10f;
    private Animator anim;
    
    private float attackCooldown = 4f;
    public float attackDelay = 4f;
    public float hitRange = 5f;

    private float attackRand;
    private bool spin = false;
    private float spinTime = 5f;
    private float spinAttackDelay = 1f;

    // Guardian Stats
    public float maxHealth = 500;
    private float currentHealth;
    private bool isPoisoned = false;
    private float poisonTick;

    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerObj = GameObject.Find("Bo");
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        attackRand = Random.value;
        playerPos = playerObj.transform.position;
        transform.LookAt(playerPos);

        if(Vector3.Distance(transform.position, playerPos) > aggro){
            return;
        }

        if(Vector3.Distance(transform.position, playerPos) >= MinDist){
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            //activate walking animation here
            //anim.CrossFade("Fly Forward Fast", 0);
            anim.SetBool("Fly Forward Fast", true);
            
        }
        if(spin){
            anim.SetBool("Spin Attack", true);
            spinTime -= Time.deltaTime;
            //prevents damage from ticking every frame
            if(spinAttackDelay >= 0.5f){
                Attack();
                spinAttackDelay = 0f;
            }
            //exit case for spin attack
            if(spinTime <= 0){
                spin = false;
                spinTime = 5f;
                anim.SetBool("Spin Attack", false);
            }
        }
        if(Vector3.Distance(transform.position, playerPos) <= MaxDist){
            anim.SetBool("Fly Forward Fast", false);
            //call attacking code here
            if(attackCooldown >= attackDelay){
                attackCooldown = 0f;
                if(attackRand >= 0 && attackRand < 0.4){
                    anim.CrossFade("PunchAttack", 0);
                    Attack();
                }else if(attackRand >= 0.4 && attackRand < 0.8){
                    anim.CrossFade("SliceAttack", 0);
                    Attack();
                }else{
                    spin = true;
                }
                
                
            }
        }
        attackCooldown += Time.deltaTime;

        if(isPoisoned){
            currentHealth -= 0.05f;
            poisonTick -= Time.deltaTime;
            if(poisonTick <= 0){
                isPoisoned = false;
            }
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
            currentHealth -= 10f;
            isPoisoned = true;
            poisonTick = 4f;
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

    void Attack(){
        //make attack attempt here
        if(Vector3.Distance(transform.position, playerPos) <= hitRange){
            // call damage functions in PlayerStats here
            playerObj.GetComponent<PlayerStats>().TakeDamage(attDamage);
        }
    }
}
