using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public enum Type
    {
        Weapon,
        Armor,
        Consumable,
        Last
    }
    public enum SubType
    {
        None,
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
    public Type type;
    public SubType subType;
    public GameObject prefab;
    public ItemSlot slot;
    public string itemName;
    public float durability;
    public float weight;
    public float attack;
    public float defense;
    public Sprite image;
}


