using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public Transform itemParent;
    public ItemSlot[] slots;

    public void OnValidate()
    {
        if (itemParent!=null)
        {
            slots = itemParent.GetComponentsInChildren<ItemSlot>();
        }

        RefreshUI();
    }

    public void RefreshUI()
    {
        int i = 0;
        for (; i < items.Count&& i<slots.Length; i++)
        {
            slots[i].item = items[i];
        }

        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    public bool AddItem(Item item)
    {
        if (IsFull())
        {
            return false;
        }

        items.Add(item);
        RefreshUI();
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            RefreshUI();
            return true;
        }
        return false;
    }

    public bool IsFull()
    {
        return items.Count >= slots.Length;
    }
}
