using System.Collections.Generic;
using Itemsystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Crafting
{
    public class CraftingManager : MonoBehaviour
    {
        public static CraftingManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public CustomCursor customCursor;

        public Slot[] craftingSlots;
    
        public List<RecipeData> recipeData;
        public Slot resultSlot; 
    
        private void Update()
        {
            if (ItemManager.Instance.CurrentItem)
            {
                customCursor.ShowCursor(ItemManager.Instance.CurrentItem.itemSprite);
            }
            else
            {
                customCursor.HideCursor();
            }
        }

        /// <summary>
        /// Resets all crafting slots and the result slot
        /// </summary>
        public void Reset()
        {
            if (resultSlot.containedItem)
            {
                InventoryManager.Instance.AddItem(resultSlot.containedItem, 1);
                resultSlot.DisableImage();
                foreach (var craftingSlot in craftingSlots)
                {
                    InventoryManager.Instance.RemoveItem(craftingSlot.containedItem, 1);
                    craftingSlot.DisableImage();
                }
            }
            else
            {
                foreach (var craftingSlot in craftingSlots)
                {
                    craftingSlot.DisableImage();
                }
                resultSlot.DisableImage();
            }
            
        }
    
        /// <summary>
        /// Checks if the input items match any of the recipes
        /// </summary>
        public void CheckForCreateRecipes(){
            resultSlot.DisableImage();
            List<ItemData> items = new List<ItemData>();
            foreach(var slot in craftingSlots)
            {
                if (slot.containedItem == null) return;
                items.Add(slot.containedItem);
            }
            foreach (var recipe in recipeData)
            {
                if(RecipeHelper.CanCraftRecipe(items, recipe))
                {
                    resultSlot.EnableImage(recipe.resultItem);
                }
            }
        }
    }
}