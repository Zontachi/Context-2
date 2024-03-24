using Assets.Scripts.Crafting;
using Assets.Scripts.Itemsystem;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [Tooltip("The index of the slot in the crafting slots array")]
    public int index; 
    
    // The item that the slot contains
    public ItemData containedItem;
    
    // Reference to the Image component
    [SerializeField]
    private Image itemImage;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (UIHelper.IsPointerOverGameObject(gameObject))
            DisableImage();

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
        // Set the item and the sprite
        containedItem = item;
        itemImage.sprite = item.itemSprite;
        
        // Enable the image
        itemImage.enabled = true;
    }
}
