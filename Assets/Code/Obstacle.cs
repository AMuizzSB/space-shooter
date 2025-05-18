using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public float sclaleMax = 0.45f;
    public float sclaleMin = 0.35f;
    public GameObject explocionEffect;
    [HideInInspector]
    public float vida;

    [HideInInspector]
    public int points;
    private Slider healthBar;
    private Canvas healthBarCanvas;

    void Start()
    {
        vida = Random.Range(1f, 10f);
        healthBar = GetComponentInChildren<Slider>();
        if (healthBar != null)
        {
            healthBar.maxValue = vida;
            healthBar.value = vida;
        }

        healthBarCanvas = GetComponentInChildren<Canvas>();
        if (healthBarCanvas != null)
        {
            healthBarCanvas.enabled = false; // Disable the canvas initially
        }

        points = Random.Range(1, 10);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CreateexplocionEffectExists();
            Destroy(collision.gameObject);
            // detroy self
            Destroy(gameObject);
        }
    }

  void Update()
  {
    if (healthBar != null)
    {
        healthBar.value = vida;
        if (healthBar.value != healthBar.maxValue)
        {
            healthBarCanvas.enabled = true; // Enable the canvas when the health bar is active
        }
    }
  }

  private void CreateexplocionEffectExists()
    {
        if (explocionEffect != null)
        {
            GameObject effect = Instantiate(explocionEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f); // Destroy the effect after 2 second
        }
    }

    void ramdomSize()
    {
        float scaleFactor = Random.Range(sclaleMin, sclaleMax);
        transform.localScale = (Vector2)transform.localScale * scaleFactor;
    }
}