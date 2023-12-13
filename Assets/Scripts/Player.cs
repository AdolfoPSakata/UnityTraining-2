using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public UnityAction JumpAction;

    Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;

    public Player()
    {
        JumpAction = Jump;
    }

    {
    private void Die()
        rb = GetComponent<Rigidbody2D>();
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Die();
        }
    }
}
