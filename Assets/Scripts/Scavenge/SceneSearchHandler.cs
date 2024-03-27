using System.Collections;
using System.Collections.Generic;
using System.Linq; 
using Crafting;
using Itemsystem; 
using UnityEngine;


public class SceneSearchHandler : MonoBehaviour
{
    public string areaType;
    private Texture2D hoverCursor;


    public void Start()
    {
        hoverCursor = (Texture2D) Resources.Load("cursor_search");
    }

    public void OnClickScene()
    {
        TypeHandler();
        GlobalVariables.iTime+=120;
    }
    public void OnEnterScene()
    {
        Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
    }
    public void OnExitScene()
    {
        Cursor.SetCursor(null, new Vector2(0,0), CursorMode.Auto);
    }

    public void TypeHandler()
    {
        switch (areaType)
        {
            case "food":
                AddItem(new[] { "ramen", "candy", "soup", "can", "cookie", "rope", "plastic"});
                break;
            case "clothes":
                AddItem(new[] { "leather", "fabric", "button", "wool", "plastic", "flower", "rope" });
                break;
            default:
                AddItem(new[] { "CD", "button", "plastic", "fabric", "rope", "beans" });
                break;
        }
    }

    private void AddItem(string[] items)
    {
        foreach (var s in items)
        {
            switch (s)
            {
                case "CD":
                    GlobalVariables.iCD++;
                    InventoryManager.Instance.AddItem(GetItemByItemType(ItemType.Cd), amount: 1);
                    break;
                case "leather":
                    GlobalVariables.iLeather++;
                      InventoryManager.Instance.AddItem(GetItemByItemType(ItemType.Leather), amount: 1);
                    break;
                case "can":
                    GlobalVariables.iCan++;
                    break;
                case "flower":
                    GlobalVariables.iFlower++;
                     InventoryManager.Instance.AddItem(GetItemByItemType(ItemType.Flower), amount: 1);
                    break;
                case "wool":
                    GlobalVariables.iWool++;
                     InventoryManager.Instance.AddItem(GetItemByItemType(ItemType.Wol), amount: 1);
                    break;
                case "fabric":
                    GlobalVariables.iFabrics++;
                     InventoryManager.Instance.AddItem(GetItemByItemType(ItemType.Fabrics), amount: 1);
                    break;
                case "rope":
                    GlobalVariables.iRope++;
                     InventoryManager.Instance.AddItem(GetItemByItemType(ItemType.Rope), amount: 1);
                    break;
                case "button":
                    GlobalVariables.iButtons++;
                     InventoryManager.Instance.AddItem(GetItemByItemType(ItemType.Buttons), amount: 1);
                    break;
                case "plastic":
                    GlobalVariables.iPlastics++;
                    InventoryManager.Instance.AddItem(GetItemByItemType(ItemType.Plastic), amount: 1);
                    break;
                case "ramen":
                    GlobalVariables.iRamen++;
                    break;
                case "soup":
                    GlobalVariables.iSoup++;
                    break;
                case "candy":
                    GlobalVariables.iCandy++;
                    break;
                case "cookie":
                    GlobalVariables.iCookies++;
                    break;
            }
        }
    }
    
    private ItemData GetItemByItemType(ItemType itemType)
    {
        return InventoryManager.Instance.GetExistingItems.FirstOrDefault(item => item.type == itemType);
    }
}
