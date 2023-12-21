using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public Action JumpAction;
    public Action Died;

    Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;

    public Player()
    {
        JumpAction += Jump;
        Died += Die;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Die()
    {
        JumpAction -= Jump;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Died.Invoke();
            Die();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            print("Add point");
        }
    }
}
