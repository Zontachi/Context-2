using System.Collections;
using System.Collections.Generic;
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
        switch (areaType)
        {
            case "food":
                Debug.Log("aaaaaaaaaa");
                break;
            case "clothes":
                Debug.Log("bbbbbbbbbb");
                break;
            case "stationery":
                Debug.Log("cccccccccc");
                break;
            default:
                Debug.Log("misc");
                break;
        }
    }
}
