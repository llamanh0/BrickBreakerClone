using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float boundary = 39f;

    private void Update()
    {
        HandleMovement();
        ApplyBoundry();
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * moveInput * speed *  Time.deltaTime);
    }

    private void ApplyBoundry()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -boundary, boundary);
        transform.position = position;
    }
}
