using System.Collections;
using System.Collections.Generic;
using Crafting;
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
        GlobalVariables.iTime+=30;
    }
    public void OnEnterScene()
    {
        Debug.Log("hovercursor set");
        Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
    }
    public void OnExitScene()
    {
        Cursor.SetCursor(null, new Vector2(0,0), CursorMode.Auto);
    }

    public void TypeHandler()
    {
        Random.Range(4,101);

        switch (areaType)
        {
            case "food":
                AddItem(new[] { "ramen", "candy", "soup", "can", "cookie", "rope", "plastic"});
                break;
            case "clothes":
                AddItem(new[] { "leather", "fabric", "button", "wool", "plastic", "flower", "rope" });
                break;
            default:
                Debug.Log("misc");
                AddItem(new[] { "CD", "button", "plastic", "fabric", "rope", "beans" });
                break;
        }
        FillInventoryTexts();

    }

    private void AddItem(string[] items)
    {
        int addedItem1 = Random.Range(1, 5);
        int addedItem2 = Random.Range(1, 5);
        GlobalVariables.inventory.Add(items[addedItem1]);
        GlobalVariables.inventory.Add(items[addedItem2]);
        Debug.Log("Added " + items[addedItem1] + " to your inventory!");
        Debug.Log("Added " + items[addedItem2] + " to your inventory!");

        for (int i = 0; i < Random.Range(1,4); i++)
        {
            int addedExtraItems = Random.Range(1, items.Length - 1);
            GlobalVariables.inventory.Add(items[addedExtraItems]);
            Debug.Log("Added " + items[addedExtraItems] + " to your inventory!");
        }
    }
    public void FillInventoryTexts()
    {
        ResetVars();
        foreach (string s in GlobalVariables.inventory)
        {
            switch (s)
            {
                case "CD":
                    GlobalVariables.iCD++;
                    break;
                case "leather":
                    GlobalVariables.iLeather++;
                    break;
                case "can":
                    GlobalVariables.iCan++;
                    break;
                case "flower":
                    GlobalVariables.iFlower++;
                    break;
                case "wool":
                    GlobalVariables.iWool++;
                    break;
                case "fabric":
                    GlobalVariables.iFabrics++;
                    break;
                case "rope":
                    GlobalVariables.iRope++;
                    break;
                case "button":
                    GlobalVariables.iButtons++;
                    break;
                case "plastic":
                    GlobalVariables.iPlastics++;
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
    public void ResetVars()
    {
        GlobalVariables.iCD = 0;
        GlobalVariables.iLeather = 0;
        GlobalVariables.iCan = 0;
        GlobalVariables.iFlower = 0;
        GlobalVariables.iWool = 0;
        GlobalVariables.iFabrics = 0;
        GlobalVariables.iRope = 0;
        GlobalVariables.iButtons = 0;
        GlobalVariables.iPlastics = 0;
        GlobalVariables.iRamen = 0;
        GlobalVariables.iSoup = 0;
        GlobalVariables.iCandy = 0;
        GlobalVariables.iCookies = 0;
    }
}
