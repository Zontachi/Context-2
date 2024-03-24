using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [Tooltip("The index of the slot in the crafting slots array")]
    public int index; 
    
    // The item that the slot contains
    [HideInInspector] 
    public Item containedItem;
    
    // Reference to the Image component
    [SerializeField]
    private Image itemImage;

    /// <summary>
    /// Disable the image of the slot
    /// </summary>
    public void DisableImage()
    {
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
    public void EnableImage(Item item)
    {
        // Set the item and the sprite
        containedItem = item;
        itemImage.sprite = item.itemSprite;
        
        // Enable the image
        itemImage.enabled = true;
    }
}
