using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    public GameObject explocionEffect;
    private float damage = 10f;
    private float vida;
    private Player player;

    void Start()
    {
        vida = damage;
        // Get the player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            Obstacle obstacle = collision.GetComponent<Obstacle>();
            float obstacleVida = obstacle.vida;
            float newObstacleVida = obstacle.vida - damage;
            if (newObstacleVida <= 0)
            {
                CreateexplocionEffectExists();
                Destroy(collision.gameObject);

                // sum points to player
                player.points += obstacle.points;
            }
            else
            {
                obstacle.vida = newObstacleVida;
            }

            // check if obstacle is dead
            if (newObstacleVida <= 0)
            {
                vida = vida - (damage + newObstacleVida);
            }
            else
            {
                vida = vida - damage;
            }


            if (vida <= 0)
            {
                CreateexplocionEffectExists();
                Destroy(gameObject);
            }
        }
    }

    private void CreateexplocionEffectExists(float effectDuration = 2f)
    {
        if (explocionEffect != null)
        {
            GameObject effect = Instantiate(explocionEffect, transform.position, Quaternion.identity);
            Destroy(effect, effectDuration); // Destroy the effect after 2 second
        }
    }
    
}

   

