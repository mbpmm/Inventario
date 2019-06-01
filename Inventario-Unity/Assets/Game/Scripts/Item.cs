using UnityEngine;

[System.Serializable]
public class Item
{
    public enum type
    {
        Weapon,
        Armor,
        Consumable,
        Last
    }
    public enum subType
    {
        Sword,
        Shield,
        Bow,
        Axe,
        Helmet,
        Body,
        Shoulders,
        Boots,
        Pants,
        Gloves,
        Last
    }
    //public string type;
    //public string subType;
    public ItemSlot slot;
    public string itemName;
    public float durability;
    public float weight;
    public float attack;
    public float defense;
    public Sprite image;
}


