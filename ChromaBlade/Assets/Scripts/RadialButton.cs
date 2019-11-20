using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RadialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image circle;
    public Image icon;
    public string title;

    // which cirlce is selected?
    public RadialMenu myMenu;

    public void OnPointerEnter(PointerEventData eventData)
    {
        myMenu.selected = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myMenu.selected = null;
    }
}
