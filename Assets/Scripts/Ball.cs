using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;

    public float baseSpeed = 200.0f;
    public float maxSpeed = Mathf.Infinity;
    public float currentSpeed { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f)
                                      : Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x, y).normalized;
        rb.AddForce(direction * baseSpeed,ForceMode2D.Impulse);
        currentSpeed = baseSpeed;
    }

    public void ResetPosition()
    {
        rb.position = Vector2.zero;
        rb.velocity = Vector2.zero;
    }
    private void FixedUpdate()
    {
        Vector2 direction = rb.velocity.normalized;
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        rb.velocity = direction * currentSpeed;
    }
}
