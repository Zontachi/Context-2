using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [Tooltip("The name of the item")]
    public string itemName; 
    
    [Tooltip("The sprite of the item")]
    public Sprite itemSprite;

    private void Start()
    {
        // If the item sprite is null and the game object has an Image component,
        // set the item sprite to the Image component's sprite
        if (itemSprite == null && GetComponent<Image>() != null)
            itemSprite = GetComponent<Image>().sprite;
    }
}
