using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static event EventHandler OnGameOver;
    public static event EventHandler OnBreakBrick;

    [SerializeField] private float speed = 1f;

    [SerializeField] private GameObject _brickBreakPrefab;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch()
    {
        float x = UnityEngine.Random.Range(0, 2) == 0 ? -1f : 1f;
        float y = 1f;

        Vector2 direction = new Vector2(x, y).normalized;
        _rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            OnBreakBrick?.Invoke(this, EventArgs.Empty);

            GameObject effect = Instantiate(_brickBreakPrefab, collision.transform.position, Quaternion.identity);

            Destroy(effect, 2f);
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
        if (collision.gameObject.CompareTag("GameOver"))
        {
            OnGameOver?.Invoke(this, EventArgs.Empty);
        }
    }
}
