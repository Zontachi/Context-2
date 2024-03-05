using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMenu : MonoBehaviour
{
    public GameObject popUpMenu;

    void Start()
    {
        // Ensure pop-up menu is initially inactive
        popUpMenu.SetActive(false);
    }

    // Function to toggle the visibility of the pop-up menu
    public void TogglePopUpMenu()
    {
        popUpMenu.SetActive(!popUpMenu.activeSelf);
    }
}
