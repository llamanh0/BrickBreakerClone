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
}
