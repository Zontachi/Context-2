using UnityEngine;
using UnityEngine.UI;

public class CloseApplicationButton : MonoBehaviour
{
    void Start()
    {
        // Assuming you have attached this script to a Button component
        Button closeButton = GetComponent<Button>();

        // Add a listener to the button click event
        closeButton.onClick.AddListener(CloseApplication);
    }

    public void CloseApplication()
    {
        // Close the application
        Debug.Log("Application closed");
        Application.Quit();
    }
}
