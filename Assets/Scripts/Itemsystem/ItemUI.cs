using Assets.Scripts.Crafting;
using Assets.Scripts.Itemsystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent (typeof(Image))]

public class ItemUI: MonoBehaviour
{
    public ItemData itemData;
  
    private void Start()
    {
        GetComponent<Image> ().sprite = itemData.itemSprite; 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown (0)) 
        {
            if (UIHelper.IsPointerOverGameObject(gameObject))
                ItemManager.Instance.CurrentItem = itemData;
        }
    }
}