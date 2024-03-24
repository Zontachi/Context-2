using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingManager : MonoBehaviour
{
    private Item _currentItem;
    public CustomCursor customCursor;

    public Slot[] craftingSlots;
    
    public List<Item> itemList; 
    public string[] recipes; 
    public Item[] recipeResults; 
    public Slot resultSlot; 
    
    private void Update()
    {
        // Check the mouse input
        CheckMouseInput();
    }

    /// <summary>
    /// Checks the mouse input
    /// </summary>
    private void CheckMouseInput()
    {
        // If the left mouse button is not pressed, return
        if (!Input.GetMouseButtonUp(0)) return;
        
        // If the user is not holding and item return
        if (_currentItem == null) return;

        // Loop through all crafting slots
        foreach (Slot slot in craftingSlots)
        {
            // Check if the mouse is over the slot
            if (IsPointerOverSlot(slot))
            {
                // Set the item in the slot
                SetSlot(slot, _currentItem);
            }
        }
    }

    /// <summary>
    /// Sets an item in a slot
    /// </summary>
    /// <param name="slot">The targeted slot</param>
    /// <param name="item">The item to be set</param>
    private void SetSlot(Slot slot, Item item)
    {
        // Enable the image of the slot with the item
        slot.EnableImage(item);
        // Add the item to the item list
        itemList[slot.index] = item;
        // Reset the current item
        _currentItem = null;
        // Hide the cursor
        customCursor.HideCursor();
        
        // Check if the user is dragging an item
        CheckForCreateRecipes();
    }

    /// <summary>
    /// Checks if the mouse is over a slot
    /// </summary>
    /// <param name="slot">The slot to be checked</param>
    /// <returns>Returns boolean with ray cast result</returns>
    private bool IsPointerOverSlot(Slot slot)
    {
        // Create a new PointerEventData
        var pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        // Create a list of RayCastResults
        var results = new List<RaycastResult>();
        // RayCast from the pointer data to the results
        EventSystem.current.RaycastAll(pointerData, results);
        // Return true if the slot is in the results else false
        return results.Any(result => result.gameObject.transform.parent.gameObject == slot.gameObject);
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

        // Loop through all items in the item list and set them to null
        for (var i = 0; i < itemList.Count; i++)
            itemList[i] = null;
        
        // Disable the result slot image
        resultSlot.DisableImage();
    }

    /// <summary>
    /// Pointer for when the user clicks on a slot
    /// </summary>
    /// <param name="slot">The clicked slot</param>
    public void OnClickSlot(Slot slot)
    {
        // If the slot does not contain an item, return
        if(slot.containedItem == null) return;
        
        // Remove the item from the slot
        slot.DisableImage();
        // Remove the item from the list
        itemList[slot.index] = null;
    }

    /// <summary>
    /// Pointer for when the user clicks on an item
    /// </summary>
    /// <param name="item">The clicked item</param>
    public void OnMouseDownItem(Item item)
    {
        // Set the current item to the clicked item
        _currentItem = item;
        // Show the cursor
        customCursor.ShowCursor(item.itemSprite);
    }
    
    /// <summary>
    /// Checks if the input items match any of the recipes
    /// TODO: Revamp for new item types
    /// </summary>
    void CheckForCreateRecipes(){
        resultSlot.DisableImage();

        string currentRecipeString = ""; 
        foreach(Item item in itemList){ 
            if(item != null){ 
                currentRecipeString += item.itemName.ToLower();        
            }
            else{
                currentRecipeString += "null"; 
            }
        }

        for (int i = 0; i < recipes.Length; i++){
            if (recipes [i] == currentRecipeString)
            {
                resultSlot.EnableImage(recipeResults[i]);
                InventoryManager.Instance.inventoryItems.Add(recipeResults[i]);
            }
        }
    }
}