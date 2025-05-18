using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 2f;
    private bool wasVisible = false;

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)transform.position + Vector2.down *speed * Time.deltaTime;
    }

  void FixedUpdate()
  {
    if (!wasVisible && gameObject.GetComponent<SpriteRenderer>().isVisible)
    {
      wasVisible = true;
    }

    if (wasVisible && !gameObject.GetComponent<SpriteRenderer>().isVisible)
    {
      Destroy(gameObject);
    }
  }
}
