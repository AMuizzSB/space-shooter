using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject pickupEffect;
    private float shootInterval = 0.1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            player.shootInterval = shootInterval;
            CreatePickupEffectIfExists();
            Destroy(gameObject);
        }
    }

    private void CreatePickupEffectIfExists()
    {
        if (pickupEffect != null)
        {
            GameObject effect = Instantiate(pickupEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f); // Destroy the effect after 2 second
        }
    }
}
