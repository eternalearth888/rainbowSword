 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [System.Serializable]
    public class Action
    {
        public Sprite sprite;
        public string title;
    }

    public Action[] options;

    private void Start()
    {
        // all sprites will be at full opacity
        //SpriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void Update()
    {
        // Tell the Canvas to spawn
        if(Input.GetKeyDown("q")){
            RadialMenuSpawner.ins.SpawnMenu(this);
        }
    }
}
