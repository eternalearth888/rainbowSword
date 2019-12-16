using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using RadialButton;

public class SwordSwapper : MonoBehaviour
{
    // MOVE THE CONTENTS OF THIS FILE TO RadialMenu.cs !!!
    
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
    
    public static int selectedSword = 6;
    private int prevSel;

    private GameObject swordParent;
    
    // Start is called before the first frame update
    void Start()
    {
        //starts the game with a black sword
        newSword = Instantiate(prefabs[6], transform.position, Quaternion.identity) as GameObject;
        swordParent = GameObject.Find("Sword");
        newSword.transform.parent = swordParent.transform;
        prevSel = selectedSword;
    }

    // Update is called once per frame
    void Update()
    {
        if(selectedSword != prevSel){
            swapper();
            prevSel = selectedSword;
        }
        
    }


    void swapper(){
        // The Update code listens for a sword swap input, then destroys the sword's existing prefab and replaces it 
        if(selectedSword == 0){
            Destroy(newSword);
            newSword = Instantiate(prefabs[0], transform.position, Quaternion.identity) as GameObject;
        }
        if(selectedSword == 1){
            Destroy(newSword);
            newSword = Instantiate(prefabs[1], transform.position, Quaternion.identity) as GameObject;
        }
        if(selectedSword == 2){
            Destroy(newSword);
            newSword = Instantiate(prefabs[2], transform.position, Quaternion.identity) as GameObject;
        }
        if(selectedSword == 3){
            Destroy(newSword);
            newSword = Instantiate(prefabs[3], transform.position, Quaternion.identity) as GameObject;
        }
        if(selectedSword == 4){
            Destroy(newSword);
            newSword = Instantiate(prefabs[4], transform.position, Quaternion.identity) as GameObject;
        }
        if(selectedSword == 5){
            Destroy(newSword);
            newSword = Instantiate(prefabs[5], transform.position, Quaternion.identity) as GameObject;
        }
        
        swordParent = GameObject.Find("Sword");
        newSword.transform.parent = swordParent.transform;
        newSword.transform.rotation = transform.rotation;
    }
}
