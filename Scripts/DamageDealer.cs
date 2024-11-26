using UnityEngine;

public class DamageDealer : MonoBehaviour {
    [SerializeField] int damage = 100;

    public int GetDamage() {
        return this.damage;
    }

    public void Hit() {
        Destroy(gameObject);
    }
}