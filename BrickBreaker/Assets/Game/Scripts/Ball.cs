using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1f : 1f;
        float y = 1f;

        Vector2 direction = new Vector2(x, y).normalized;
        _rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            float ballX = transform.position.x;
            float paddleX = collision.transform.position.x;
            float paddleWidth = collision.collider.bounds.size.x;
            float offset = (ballX - paddleX) / (paddleWidth / 2f); // Clamp (-1,1)

            Vector2 currentVelocity = GetComponent<Rigidbody2D>().velocity;
            float speed = currentVelocity.magnitude; // Save old speed

            Vector2 newDirection = new Vector2(offset, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = newDirection * speed;
        }
    }
}
