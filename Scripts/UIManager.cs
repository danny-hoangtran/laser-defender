using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI pointText;

    private Player player;

    void Start() {
        player = FindFirstObjectByType<Player>();
    }

    void Update() {
        if (player != null && healthText != null) {
            healthText.text = player.GetHealth().ToString();
        }

        if(pointText != null) {
            pointText.text = GameSession.GetInstance().GetPoint().ToString();
        }
    }
}
