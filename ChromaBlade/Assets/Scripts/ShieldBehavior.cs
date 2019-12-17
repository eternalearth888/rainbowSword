using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    public float timer = 1.2f;
    private GameObject bo;
    private Vector3 loc;
    
    // Start is called before the first frame update
    void Start()
    {
        bo = GameObject.Find("Bo");
    }

    // Update is called once per frame
    void Update()
    {
        loc = new Vector3(bo.transform.position.x, bo.transform.position.y + 1, bo.transform.position.z);
        transform.position = loc;
        transform.rotation = bo.transform.rotation;
        timer -= Time.deltaTime;
        if(timer <= 0){
            Destroy(gameObject);
        }
    }
}
