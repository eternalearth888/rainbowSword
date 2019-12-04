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
    private bool isWalk;
    private float walkTimer;

    
    
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

        AnimatorClipInfo[] ci;
        ci = anim.GetCurrentAnimatorClipInfo(0);

        if(Vector3.Distance(transform.position, playerPos) >= MinDist){
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            //activate walking animation here
            if (ci[0].clip.name != "Run Forward In Place"){
                // Avoid any reload.
                Debug.Log(ci[0].clip.name);
                walkAnim();
            }
        }

        if(Vector3.Distance(transform.position, playerPos) <= MaxDist){
            //call attacking code here
            //anim.CrossFade("Idle", 0);
        }
    }

    void walkAnim(){
        //anim.StopPlayback();
        anim.CrossFade("Run Forward In Place", 0);
        
    }
}
