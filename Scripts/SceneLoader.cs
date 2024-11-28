using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour{
    private static SceneLoader instance;

    public static SceneLoader GetInstance() {
        if(instance == null) {
            GameObject gameObject = new GameObject("SceneLoader");
            instance = gameObject.AddComponent<SceneLoader>();
        }
        return instance;
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadSceneName(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneIndex(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadStartScene() {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOverScene() {
        SceneManager.LoadScene("GameOver");
    }
}