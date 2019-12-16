using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenuSpawner : MonoBehaviour
{

    public static RadialMenuSpawner ins;
    public RadialMenu menuPrefab;


    void Awake()
    {
        ins = this;   
    }

    // Interactable calls this to create the menu
    public void SpawnMenu(Interactable obj)
    {
        RadialMenu newMenu = Instantiate(menuPrefab) as RadialMenu;
        // plop it in the middle of the screen
        newMenu.transform.SetParent(transform, false);
        // plop it where the mouse has clicked
        //newMenu.transform.position = Input.mousePosition;

        newMenu.SpawnButtons(obj);
    }

}
