using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Change "level-2" to your first gameplay scene name
    public string sceneToLoad = "level-2";

    public void Restart()
    {
        Debug.Log("Restart button pressed, loading: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}