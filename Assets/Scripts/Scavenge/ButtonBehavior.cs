using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonBehavior : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private Button pb;
    public Sprite oldSprite, newSprite;
    void Start()
    {
        pb = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pb.image.sprite = newSprite;
        Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pb.image.sprite = oldSprite;
    }
}