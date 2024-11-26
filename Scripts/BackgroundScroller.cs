using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
    [SerializeField] float scrollSpeed = 0.5f;
    [SerializeField] Vector2 offset;
    private Material material;

    void Start() {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(0f, scrollSpeed);
    }

    void Update() {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
