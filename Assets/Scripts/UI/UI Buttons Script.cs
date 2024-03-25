using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void TrainClicked()
    {
        Debug.Log("Loading new area");
        //SceneManager.LoadScene(sceneName);
    }
    public void BuildingClicked()
    {
        Debug.Log("Loading new area");
        //SceneManager.LoadScene(sceneName);
    }
    public void HouseClicked()
    {
        Debug.Log("Loading new area");
        SceneManager.LoadScene("UI Scene 1");
    }
    public void BathClicked()
    {
        Debug.Log("Loading new area");
        //SceneManager.LoadScene(sceneName);
    }
    public void TreeClicked()
    {
        Debug.Log("Loading new area");
        //SceneManager.LoadScene(sceneName);
    }
    public void TentClicked()
    {
        Debug.Log("Loading new area");
        //SceneManager.LoadScene(sceneName);
    }
    public void ArenaClicked()
    {
        Debug.Log("Loading new area");
        //SceneManager.LoadScene(sceneName);
    }
    public void CraftingClicked()
    {
        Debug.Log("Loading new area");
        SceneManager.LoadScene("Crafting system");
    }
    public void DressupClicked()
    {
        Debug.Log("Loading new area");
        SceneManager.LoadScene("Dressup");
    }
}
