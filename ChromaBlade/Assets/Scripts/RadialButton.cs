using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RadialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   
    public Image icon;
    public string title;

    // which crystal is selected?
    public RadialMenu myMenu;

    Vector3 defaultScale;


    public void OnPointerEnter(PointerEventData eventData)
    {
        myMenu.selected = this;
        defaultScale = icon.transform.localScale;
        icon.transform.localScale = defaultScale * 2;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myMenu.selected = null;
        icon.transform.localScale = defaultScale;
    }
}
