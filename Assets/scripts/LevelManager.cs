using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    static int activeGameScene;

    // Loads new level
    public void LoadLevel(string name) {
        Brick.breakableCount = 0;
        Debug.Log("Level load requested for " + name);
        SceneManager.LoadScene(name);
    }

    // Loads next level according to build index
    public void LoadNextLevel() {
        Brick.breakableCount = 0;
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void QuitRequest() {
        Debug.Log("Quit requested.");
        Application.Quit();
    }
}
