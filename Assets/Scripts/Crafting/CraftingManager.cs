using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Crafting;
using Assets.Scripts.Itemsystem;
using UnityEngine;
using UnityEngine.EventSystems;

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
    
    public List<RecipeData> recipeDatas;
    public ItemData[] recipeResults; 
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
        // Loop through all crafting slots and disable their images
        foreach (var craftingSlot in craftingSlots)
        {
            craftingSlot.DisableImage();
        }
        
        // Disable the result slot image
        resultSlot.DisableImage();
    }
    
    /// <summary>
    /// Checks if the input items match any of the recipes
    /// TODO: Revamp for new item types
    /// </summary>
    public void CheckForCreateRecipes(){
        resultSlot.DisableImage();
        List<ItemData> items = new List<ItemData>();
        foreach(var slot in craftingSlots)
        {
            if (slot.containedItem == null) return;
            items.Add(slot.containedItem);
        }
        foreach (var recipe in recipeDatas)
        {
            if(RecipeHelper.CanCraftRecipe(items, recipe))
            {
                resultSlot.EnableImage(recipe.resultItem);
            }
        }
        
     
    }
}