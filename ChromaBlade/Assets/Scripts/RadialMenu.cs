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
        if (Input.GetMouseButtonUp(0))
        {
            //PUT BUTTON ACTIONS IN HERE IF THEY DESELECT ON AN OPTION
            if (selected)
            {
                Debug.Log(selected.title + " was selected");
            }
            // Otherwise exit menu
            Destroy(gameObject);
        }
    }
}
