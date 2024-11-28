using UnityEngine;

public class GameSession : MonoBehaviour {
    private static GameSession instance;
    private int point;

    public static GameSession GetInstance() {
        if(instance == null) {
            GameObject gameObject = new GameObject("GameSession");
            instance = gameObject.AddComponent<GameSession>();
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
        point = 0;
    }
    
    public void Restart() {
        SetPoint(0);
    }

    public int GetPoint() {
        return point;
    }

    public void SetPoint(int point) {
        this.point = point;
    }
}
