using UnityEngine;
using UnityEngine.UI;

// Guarantees that an Image component is attached to the game object
[RequireComponent(typeof(Image))]
public class CustomCursor : MonoBehaviour
{
    private Image _cursorImage;

    private void Start()
    {
        // Get the Image component
        _cursorImage = GetComponent<Image>();
    }
    

    void Update()
    {
        // Update the cursor position
        transform.position = Input.mousePosition;
    }

    /// <summary>
    /// Shows the cursor with the specified sprite
    /// </summary>
    /// <param name="sprite">The sprite to be displayed</param>
    public void ShowCursor(Sprite sprite)
    {
        // Enable the cursor image and set the sprite
        _cursorImage.enabled = true;
        _cursorImage.sprite = sprite;
    }
    
    /// <summary>
    /// Hides the cursor
    /// </summary>
    public void HideCursor()
    {
        // Disable the cursor image and reset the sprite
        _cursorImage.enabled = false;
        _cursorImage.sprite = null;
    }
}
