using UnityEngine;

namespace Itemsystem
{
    [CreateAssetMenu (menuName = "Item/ItemData")]

    public class ItemData : ScriptableObject
    {
        public ItemType type;
        public Sprite itemSprite; 
    }
}