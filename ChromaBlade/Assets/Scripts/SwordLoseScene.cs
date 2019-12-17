using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordLoseScene : MonoBehaviour
{

    public GameObject[] prefabs;
    private GameObject endSword;
    private int lastPick = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastPick = SwordSwapper.selectedSword;
        endSword = Instantiate(prefabs[lastPick], transform.position, Quaternion.identity) as GameObject;

    }

}
