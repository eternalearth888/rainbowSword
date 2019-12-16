using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
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

    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerObj.transform.position;
        transform.LookAt(playerPos);

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
