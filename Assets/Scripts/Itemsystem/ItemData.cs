using UnityEditor;
using UnityEngine;

[CreateAssetMenu (menuName = "Item/ItemData")]

public class ItemData : ScriptableObject
{
    public ItemType type;
    public Sprite itemSprite; 
}