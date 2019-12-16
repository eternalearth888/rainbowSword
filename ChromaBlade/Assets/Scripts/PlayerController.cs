using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private float translation;
    private float strafe;
    public Transform camera;
    Animator anim;
    private Vector3 currentPos;
    private Vector3 lastPos;

    public static bool isAttacking = false;
    private float attackTimer = 1f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponent<Animator>();
        currentPos = transform.position;
        lastPos = currentPos;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;

        float yRot = camera.transform.eulerAngles.y;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRot, transform.eulerAngles.z);
        
        //handles idle vs running animations
        if(currentPos != lastPos){
            anim.SetBool("Moving", true);
        }else{
            anim.SetBool("Moving", false);
        }
        //character movement
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(strafe, 0, translation);

        //Fire1 = left click
        //plays a random attack animation
        if(Input.GetButtonDown("Fire1")){
            SwordSwing();
        }
        
        if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
        if(Input.GetKeyDown("q")){
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
        if(Input.GetKeyUp("q")){
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(isAttacking){
            if(attackTimer <= 0f){
                isAttacking = false;
            }
        }
        attackTimer -= Time.deltaTime;
        lastPos = currentPos;
    }

    void SwordSwing(){
        
        if(SwordSwapper.selectedSword == 0){
            anim.CrossFade("2Hand-Sword-Attack2", 0);
            isAttacking = true;
            attackTimer = 1.6f;
        }
        if(SwordSwapper.selectedSword == 1){
            anim.CrossFade("2Hand-Sword-Attack1", 0);
            isAttacking = true;
            attackTimer = 0.3f;
        }
        if(SwordSwapper.selectedSword == 2){
            anim.CrossFade("2Hand-Sword-Attack3", 0);
            isAttacking = true;
            attackTimer = 1.2f;
        }
        if(SwordSwapper.selectedSword == 3){
            anim.CrossFade("2Hand-Sword-Attack6", 0);
            isAttacking = true;
            attackTimer = 1.2f;
        }
        if(SwordSwapper.selectedSword == 4){
            anim.CrossFade("2Hand-Sword-Attack4", 0);
            isAttacking = true;
            attackTimer = 1.2f;
        }
        if(SwordSwapper.selectedSword == 5){
            anim.CrossFade("2Hand-Sword-Attack5", 0);
            isAttacking = true;
            attackTimer = 1.2f;
        }
    }

    void FootL(){

    }
    void FootR(){

    }
    void Hit(){
        
    }
}
