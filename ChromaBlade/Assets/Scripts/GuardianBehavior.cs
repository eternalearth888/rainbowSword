﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianBehavior : MonoBehaviour
{
    public GameObject playerObj;
    private Vector3 playerPos;
    public float MoveSpeed;
    public float MaxDist;
    public float MinDist;
    private Animator anim;
    
    private float attackCooldown = 4f;
    public float attackDelay = 4f;
    public float hitRange = 5f;

    private float attackRand;
    private bool spin = false;
    private float spinTime = 5f;
    private float spinAttackDelay = 1f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attackRand = Random.value;
        playerPos = playerObj.transform.position;
        transform.LookAt(playerPos);

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
    }

    void Attack(){
        //make attack attempt here
        if(Vector3.Distance(transform.position, playerPos) <= hitRange){
            // call damage functions in PlayerStats here
            
        }
        // else{
        //     // "miss" case, remove this else statement if not needed
        // }
        
    }
}
