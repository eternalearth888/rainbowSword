using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    public RadialButton buttonPrefab;
    public RadialButton selected;

    
    public void SpawnButtons(Interactable obj)
    {
        for (int i = 0; i < obj.options.Length; i++)
        {
            RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
            newButton.transform.SetParent(transform, false);

            // MAKE CIRCLE BY PUTTING EACH BUTTON IN THE LIST IN A DIFFERENT
            // SPOT TO CREATE A CIRCLE SHAPE/ILLUSION
            float theta = (2 * Mathf.PI / obj.options.Length) * i;

            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);

            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * 150f;

            // set the color to what you have it set in unity
            newButton.circle.color = obj.options[i].color;

            // set the sprite you want to have in unity
            newButton.icon.sprite = obj.options[i].sprite;

            // set the title you want in unity
            newButton.title = obj.options[i].title;

            // selected option
            newButton.myMenu = this;
        }
    }

    void Update()
    {
        if (Input.GetKeyUp("q"))
        {
            //PUT BUTTON ACTIONS IN HERE IF THEY DESELECT ON AN OPTION
            if (selected)
            {
                Debug.Log(selected.title + " was selected");
                if(selected.title == "Red"){
                    SwordSwapper.selectedSword = 0;
                }
                if(selected.title == "Orange"){
                    SwordSwapper.selectedSword = 1;
                }
                if(selected.title == "Yellow"){
                    SwordSwapper.selectedSword = 2;
                }
                if(selected.title == "Green"){
                    SwordSwapper.selectedSword = 3;
                }
                if(selected.title == "Blue"){
                    SwordSwapper.selectedSword = 4;
                }
                if(selected.title == "Purple"){
                    SwordSwapper.selectedSword = 5;
                }
            }
            // Otherwise exit menu
            Destroy(gameObject);
        }
    }
}
