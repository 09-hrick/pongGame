using UnityEngine;

public class ComputerPaddle : Paddle
{
    [SerializeField]
    public Rigidbody2D ball;
    private void FixedUpdate()
    {
        if (ball.velocity.x > 0f)
        {
            if (ball.position.y > transform.position.y)
            {
                rb.AddForce(Vector2.up * speed);
            }
            else if (ball.position.y < transform.position.y)
            {
                rb.AddForce(Vector2.down * speed);
            }
        }
        else
        {
            if (transform.position.y > 0.0f)
            {
                rb.AddForce(Vector2.down * speed);
            }
            else if (transform.position.y < 0.0f)
            {
                rb.AddForce(Vector2.up * speed);
            }
        }
    }
}
