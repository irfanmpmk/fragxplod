using UnityEngine;

public class GrenadeController : MonoBehaviour {
    public float throwForce = 10f;
    public GameObject grenadePrefab;
    
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            ThrowGrenade();
        }
    }
    
    void ThrowGrenade() {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        if (rb != null) {
            rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        }
    }
}