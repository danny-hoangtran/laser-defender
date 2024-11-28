using UnityEngine;

public class EnemyAudio : MonoBehaviour {
    [SerializeField] AudioClip shootSFX;
    [SerializeField] AudioClip destroySFX;

    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayShootSFX() {
        audioSource.PlayOneShot(shootSFX);
    }

    public void PlayDestroySFX() {
        audioSource.PlayOneShot(destroySFX);
    }
}
