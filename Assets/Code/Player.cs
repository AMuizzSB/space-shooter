using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  public int points = 0;
  public Projectile projectilePrefab;
  public float shootInterval ;
  private float shootTimer;
  public float movementSpeed = 5f;

  private float spriteWidth;
  private float spriteHeight;

  void Start()
  {
    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    if (spriteRenderer != null)
    {
      float pixelsPerUnit = spriteRenderer.sprite.pixelsPerUnit;

      spriteWidth = spriteRenderer.size.x * pixelsPerUnit;
      spriteHeight = spriteRenderer.size.y * pixelsPerUnit;
    }
    else
    {
      Debug.LogError("SpriteRenderer not found on the player object.");
    }
      
  }

  void Update()
  {
    Move();
    WASDControls();
    shootTimer -= Time.deltaTime;
    Shoot();
  }
  void Move()
  {
    if (Input.GetMouseButton(0))
    {
      Vector2 mousePos = Input.mousePosition;
      Vector2 realPos = Camera.main.ScreenToWorldPoint(mousePos);
      transform.position = realPos;
    }
  }

  void Shoot()
  {
    if (shootTimer <= 0)
    {
      Instantiate(projectilePrefab, transform.position,   Quaternion.identity);
      shootTimer = shootInterval;
    }
  }

  void WASDControls()
  {
    Vector3 newPosition = transform.position;
    if (Input.GetKey(KeyCode.W))
    {
      newPosition += Vector3.up * Time.deltaTime * movementSpeed;
    }
    if (Input.GetKey(KeyCode.S))
    {
      newPosition += Vector3.down * Time.deltaTime * movementSpeed;
    }
    if (Input.GetKey(KeyCode.A))
    {
      newPosition += Vector3.left * Time.deltaTime * movementSpeed;
    }
    if (Input.GetKey(KeyCode.D))
    {
      newPosition += Vector3.right * Time.deltaTime * movementSpeed;
    }

    // Check if the new position is within the screen bounds
    Vector3 screenPos = Camera.main.WorldToScreenPoint(newPosition);
    float minWidth = spriteWidth;
    float maxWidth = Screen.width - spriteWidth;
    float minHeight = spriteHeight;
    float maxHeight = Screen.height - spriteHeight;
    if (
      screenPos.x < minWidth ||
      screenPos.x > maxWidth ||
      screenPos.y < minHeight ||
      screenPos.y > maxHeight
    )
    {
      return; // Don't move if the new position is outside the screen bounds
    }
    // Update the player's position
    transform.position = newPosition;
  }
}