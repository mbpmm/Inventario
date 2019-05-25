using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ScriptableObjectItem", menuName = "Inventario/ScriptableObjectItem" + "", order = 1)]
public class ScriptableObjectItem : ScriptableObject
{
    //https://docs.unity3d.com/Manual/class-ScriptableObject.html
    public string itemName;
    public float attack;
    public float defense;
    public Sprite image;
}


