using Itemsystem;
using UnityEngine;
using UnityEngine.UI;

namespace Crafting
{
    public class Slot : MonoBehaviour
    {
        // The item that the slot contains
        [HideInInspector] public ItemData containedItem;
        [SerializeField] bool isCraftingSlot = true;
    
        // Reference to the Image component
        [SerializeField]
        private Image itemImage;

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            if (UIHelper.IsPointerOverGameObject(gameObject))
            {
                DisableImage();
                CraftingManager.Instance.CheckForCreateRecipes();
            }
                

            if (ItemManager.Instance.CurrentItem == null) return;
        
            if (UIHelper.IsPointerOverGameObject(gameObject))
            {
                EnableImage(ItemManager.Instance.CurrentItem);
                ItemManager.Instance.CurrentItem = null;
                CraftingManager.Instance.CheckForCreateRecipes();
            }
        }

        /// <summary>
        /// Disable the image of the slot
        /// </summary>
        public void DisableImage()
        {
            if(containedItem && isCraftingSlot) InventoryManager.Instance.AddItem(containedItem, 1);
            // Reset the item and the sprite
            containedItem = null;
            itemImage.sprite = null;
        
            // Disable the image
            itemImage.enabled = false;
        }
    
        /// <summary>
        /// Enables the image of the slot
        /// </summary>
        /// <param name="item">The items that the slot should display</param>
        public void EnableImage(ItemData item)
        {
            if(ItemManager.Instance.CurrentItem && isCraftingSlot) InventoryManager.Instance.RemoveItem(ItemManager.Instance.CurrentItem, 1);
            // Set the item and the sprite
            containedItem = item;
            itemImage.sprite = item.itemSprite;
        
            // Enable the image
            itemImage.enabled = true;
        }
    }
}
