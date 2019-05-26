using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Inventario/Item" + "", order = 1)]
public class Item : ScriptableObject
{
    public string type;
    public string subType;
    public ItemSlot slot;
    public string itemName;
    public float durability;
    public float weight;
    public float attack;
    public float defense;
    public Sprite image;
}


