using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwapper : MonoBehaviour
{
    // The "prefabs" array contains all of the sword prefabs to be used, stored in order as follows:
    // 0 = red
    // 1 = orange 
    // 2 = yellow
    // 3 = green
    // 4 = blue
    // 5 = purple
    // 6 = black
    public GameObject[] prefabs;
    private GameObject newSword;
    
    // Start is called before the first frame update
    void Start()
    {
        //starts the game with a black sword
        newSword = Instantiate(prefabs[6], transform.position, Quaternion.identity) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // The Update code listens for a sword swap input, then destroys the sword's existing prefab and replaces it 
        if(Input.GetKeyDown("1")){
            Destroy(newSword);
            newSword = Instantiate(prefabs[0], transform.position, Quaternion.identity) as GameObject;
        }
        if(Input.GetKeyDown("2")){
            Destroy(newSword);
            newSword = Instantiate(prefabs[1], transform.position, Quaternion.identity) as GameObject;
        }
        if(Input.GetKeyDown("3")){
            Destroy(newSword);
            newSword = Instantiate(prefabs[2], transform.position, Quaternion.identity) as GameObject;
        }
        if(Input.GetKeyDown("4")){
            Destroy(newSword);
            newSword = Instantiate(prefabs[3], transform.position, Quaternion.identity) as GameObject;
        }
        if(Input.GetKeyDown("5")){
            Destroy(newSword);
            newSword = Instantiate(prefabs[4], transform.position, Quaternion.identity) as GameObject;
        }
        if(Input.GetKeyDown("6")){
            Destroy(newSword);
            newSword = Instantiate(prefabs[5], transform.position, Quaternion.identity) as GameObject;
        }
    }
}
