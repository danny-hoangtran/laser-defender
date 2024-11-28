using UnityEngine;

public class ButtonEventHandler : MonoBehaviour {
    public void StartGame() {
        SceneLoader.GetInstance().LoadNextScene();
        GameSession.GetInstance().Restart();
    }

    public void RestartGame() {
        SceneLoader.GetInstance().LoadStartScene();
    }

}