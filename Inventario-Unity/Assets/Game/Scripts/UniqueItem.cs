using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
[CreateAssetMenu(fileName = "UniqueItem", menuName = "Inventario/Items/Unique Item" + "", order = 1)]
public class UniqueItem : ScriptableObject 
{
    public Item.Type type;
    public Item.SubType subType;
    public ItemSlot slot;
    public string itemName;
    public float durability;
    public float weight;
    public float attack;
    public float defense;
    public Sprite image;
}