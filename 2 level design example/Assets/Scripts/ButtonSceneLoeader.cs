using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    [Tooltip("The name of the scene to load when the button is pressed.")]
    public string sceneName;

    /// <summary>
    /// Method to be called when the button is pressed.
    /// </summary>
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("ButtonSceneLoader: Scene name is not set.");
        }
    }
}