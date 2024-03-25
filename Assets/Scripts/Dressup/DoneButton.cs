using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // De naam van de scene waarnaar je wilt overschakelen
    public string sceneName;

    // Methode die wordt aangeroepen wanneer er op de knop wordt geklikt
    public void ChangeToScene()
    {
        // Scene wordt geladen op basis van de opgegeven naam
        SceneManager.LoadScene(sceneName);
    }

    
}