using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private Item _item;
    public Item item
    {
        get {return _item; }
        set
        {
            _item = value;
            if (_item==null)
            {
                icon.enabled=false;
            }
            else
            {
                icon.sprite = _item.image;
                icon.enabled = true;
            }
        }
    }
    public Image icon;

    private void OnValidate()
    {
        if (icon==null)
        {
            icon=GetComponent<Image>();
        }
    }
}
